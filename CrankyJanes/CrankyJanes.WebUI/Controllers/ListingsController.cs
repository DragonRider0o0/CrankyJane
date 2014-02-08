using CrankyJanes.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrankyJanes.WebUI.Controllers
{
    [Authorize(Roles = UserRoles.StandardUser)]
    public class ListingsController : Controller
    {
        //
        // GET: /Listings/

        [HttpGet]
        public ActionResult SearchResults()
        {
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Your listing page.";
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            using (var context = CoreData.Context)
            {
                var categories = new List<Category>
                {
                    new Category {CategoryName = "Select a Category", ID = -1}
                };

                categories.AddRange(context.FilteredCategories.OrderBy(c => c.CategoryName).ToList());
                ViewBag.categories = categories;

                return View(new Listing() { ListingProperties = new List<ListingProperty>() });
            }
        }

        [HttpPost]
        public ActionResult UpdateProperties(int id)
        {
            Listing listing = null;
            if (id > -1)
            {
                listing = new Listing() { ListingProperties = new List<ListingProperty>(), CategoryID = id };
                using (var context = CoreData.Context)
                {
                    var category = context.Categories
                        .Include("PropertySpecifications")
                        .Include("PropertySpecifications.ValidationRule")
                        .Include("ParentCategory")
                        .Include("ParentCategory.PropertySpecifications")
                        .Include("ParentCategory.PropertySpecifications.ValidationRule")
                        .SingleOrDefault(c => c.ID == listing.CategoryID);

                    var dollars = context.ValidationRules.Where(x => x.Name == "Dollars");

                    var categoryHeirarchy = new Stack<Category>();
                    listing.Category = category;
                    do
                    {
                        categoryHeirarchy.Push(category);
                        category = category.ParentCategory;
                    } while (category != null);

                    while (categoryHeirarchy.Any())
                    {
                        category = categoryHeirarchy.Pop();
                        foreach (var spec in category.PropertySpecifications)
                        {
                            var prop = spec.ToProperty();
                            listing.ListingProperties.Add(prop);
                        }
                    }
                }
            }

            return PartialView("_PropertyFields", listing);

            //return Json(listing);
        }

        [HttpPost]
        public ActionResult Create(Listing listing)
        {
            if (ModelState.IsValid && listing.ListingProperties.All(x => x.IsValid()))
            {
                using (var context = CoreData.Context)
                {
                    listing.Category = context.Categories.SingleOrDefault(c => c.ID == listing.CategoryID);
                    listing.Owner = this.GetUser(context);
                    listing.Owner.Listings.Add(listing);
                    context.SaveChanges();
                    return RedirectToAction("ViewDetails", listing.ID);
                }
            }
            else
            {
                return View(listing);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ViewDetails(long id = -1)
        {
            using (var context = CoreData.Context)
            {
                var listing = context.Listings.SingleOrDefault(l => l.ID == id);
                return View(listing);
            }
        }

        [HttpGet]
        public ActionResult MyListings()
        {
            using (var context = CoreData.Context)
            {
                var user = this.GetUser(context);
                var listings = context.Listings
                    .Include("ListingProperties")
                    .Where(l => l.Owner.UserName == user.UserName).ToArray();
                return View(listings);
            }
        }
    }
}


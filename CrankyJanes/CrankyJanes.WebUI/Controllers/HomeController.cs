using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrankyJanes.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult GetValidationRules()
        {
            using(var context = CoreData.Context)
            {
                var rules = context.ValidationRules.ToArray();
                return Json(rules, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetValidationRule(string name)
        {
            using (var context = CoreData.Context)
            {
                var rule = context.ValidationRules.SingleOrDefault(x => x.Name == name);
                return Json(rule, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult SearchResults()
        {
            ViewBag.Message = "Search Results";

            return View();
        }

        public ActionResult ProductDetail()
        {
            ViewBag.Message = "Product detail page.";

            return View();
        }
    }
}

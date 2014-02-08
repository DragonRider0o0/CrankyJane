namespace CrankyJanes.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CrankyJanes.Core;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<CrankyJanes.Data.EntityDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CrankyJanes.Data.EntityDataContext db)
        {
            var required = new ValidationRule { Name = "Required", ValidationRegex = @"^\s{0,}\S+.{0,}?$", Message = "Please enter a value." };
            var numeric = new ValidationRule { Name = "Numeric", ValidationRegex = @"^[0-9]*(.[0-9]{2})?$", Message = "Please enter a numeric value." };
            var integer = new ValidationRule { Name = "Integer", ValidationRegex = @"^[0-9]+$", Message = "Please enter a valid integer value." };
            var dollars = new ValidationRule { Name = "Dollars", ValidationRegex = @"^[0-9]*(.[0-9]{2})?$", Message = "Please enter a value US dollar amount." };
            var year = new ValidationRule { Name = "Year", ValidationRegex = @"^([0-9]{4}){0,1}$", Message = "Please enter a year in the format yyyy." };
            var isbn = new ValidationRule{Name = "ISBN", ValidationRegex=@"^[0-9]{10}([0-9]{3})?$", Message="Please enter a 10 or 13 digit ISBN number with no spaces or dashes"};


            var validationRules = new[]
                {
                    required,
                    numeric,
                    integer,
                    dollars,
                    year,
                    isbn
                };            

            var baseCategory = new Category
            {
                CategoryName = EntityDataContext.BaseCategoryName,
                PropertySpecifications = new[]
                    {
                        new ListingPropertySpecification {PropertyName="AskingPrice", IsRequired = true, ValidationRule = dollars},
                        new ListingPropertySpecification {PropertyName="Description", IsRequired = true, ValidationRule = required},
                        new ListingPropertySpecification {PropertyName="Condition", IsRequired = true, ValidationRule = required},
                    },
            };

            var bookCategory = new Category()
                {
                    ParentCategory = baseCategory,
                    CategoryName = "Books",
                    PropertySpecifications = new[]
                    {
                        new ListingPropertySpecification {PropertyName="Title", IsRequired = true, ValidationRule = required},
                        new ListingPropertySpecification {PropertyName="Author", IsRequired = true, ValidationRule = required},
                        new ListingPropertySpecification {PropertyName="Publisher", IsRequired = false, ValidationRule = null},
                        new ListingPropertySpecification {PropertyName="Year Published", IsRequired = false, ValidationRule = year},
                    },
                };

            var textbookCategory = new Category()
            {
                ParentCategory = bookCategory,
                CategoryName = "Text Books",
                PropertySpecifications = new[]
                    {
                        new ListingPropertySpecification {PropertyName="ISBN", IsRequired = true, ValidationRule = isbn},
                        new ListingPropertySpecification {PropertyName="Edition", IsRequired = true, ValidationRule = numeric},
                    },
            };

            db.Categories.AddOrUpdate(c => c.CategoryName, bookCategory);
            db.Categories.AddOrUpdate(c => c.CategoryName, textbookCategory);

            foreach (var rule in validationRules)
            {
                db.ValidationRules.AddOrUpdate(r => r.Name, rule);
            }
        }
    }
}

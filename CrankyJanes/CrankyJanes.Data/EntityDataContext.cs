using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrankyJanes.Core;

namespace CrankyJanes.Data
{
    public class EntityDataContext : DbContext
    {
        public const string BaseCategoryName = "Listing";
        public EntityDataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ValidationRule> ValidationRules { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public IEnumerable<Category> FilteredCategories
        {
            get
            {
                return Categories.Where(c => c.CategoryName != BaseCategoryName);
            }
        }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingProperty> ListingProperties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //configure the one to many relationship between Categories and ListingPropertySpecifications 
            modelBuilder.Entity<ListingPropertySpecification>()
                .HasRequired<Category>(specification => specification.Category)
                .WithMany(category => category.PropertySpecifications)
                .HasForeignKey(specification => specification.CategoryID);

            base.OnModelCreating(modelBuilder);
        }

        public UserProfile GetUser(string userName)
        {
            var user = UserProfiles.SingleOrDefault(u => u.UserName == userName);
            return user;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrankyJanes.Core
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }

        private ICollection<Listing> _listings;
        public ICollection<Listing> Listings
        {
            get { return _listings ?? (_listings = new List<Listing>()); }
            set { _listings = value; }
        }
    }
}

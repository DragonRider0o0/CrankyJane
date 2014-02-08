using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrankyJanes.Core
{
    public class Listing
    {
        public Listing()
        {
        }

        public virtual long ID { get; set; }
        public virtual UserProfile Owner { get; set; }        
        public virtual int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public List<ListingProperty> ListingProperties { get; set; }
    }
}

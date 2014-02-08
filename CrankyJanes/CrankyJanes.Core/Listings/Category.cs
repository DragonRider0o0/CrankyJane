using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrankyJanes.Core
{
    public class Category
    {
        public virtual int ID { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<ListingPropertySpecification> PropertySpecifications {get; set;}
    }
}

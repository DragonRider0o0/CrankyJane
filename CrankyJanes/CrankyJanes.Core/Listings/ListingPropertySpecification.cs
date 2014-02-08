using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrankyJanes.Core
{
    public class ListingPropertySpecification
    {
        public virtual int ID { get; set; }
        public virtual string PropertyName { get; set; }
        public virtual bool IsRequired { get; set; }
        public virtual int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("ValidationRule")]
        public virtual string ValidationRuleName { get; set; }
        public virtual ValidationRule ValidationRule { get; set; }

        public ListingProperty ToProperty()
        {
            return new ListingProperty
            {
                PropertyName = PropertyName,
                IsRequired = IsRequired,
                ValidationRuleName = ValidationRuleName,
                ValidationRule = ValidationRule
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrankyJanes.Core
{
    public class ListingProperty
    {
        public ListingProperty()
        {
            PropertyValue = string.Empty;
        }

        public virtual long ID { get; set; }
        public virtual string PropertyName { get; set; }
        public virtual string PropertyValue { get; set; }
        public virtual bool IsRequired { get; set; }

        [ForeignKey("ValidationRule")]
        public string ValidationRuleName { get; set; }
        public ValidationRule ValidationRule { get; set; }

        public bool IsValid()
        {
            var requiredSatisfied = !IsRequired || !string.IsNullOrWhiteSpace(PropertyValue);
            var validationSatisfied = ValidationRule == null ||
                Regex.IsMatch(PropertyValue, ValidationRule.ValidationRegex);

            return requiredSatisfied && validationSatisfied;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrankyJanes.Core
{
    public class ValidationRule
    {
        [Required]
        [Key]
        public string Name { get; set; }

        /// <summary>
        /// Validation regex is a regular expression string used to validate a string value.
        /// If it matches the regex it is considered valid.
        /// Regular Expressions should be valid in both javascript and c#
        /// </summary>
        [Required]
        public string ValidationRegex { get; set; }

        [Required]
        public string Message { get; set; }

        public bool IsValid(string value)
        {
            return Regex.IsMatch(value, ValidationRegex);
        }
    }
}

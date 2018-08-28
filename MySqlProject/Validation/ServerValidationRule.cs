using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MySqlProject.Validation
{
    class ServerValidationRule:ValidationRule
    {

       
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "The right pattern is: XXX.XXX.XXX.XXX or localhost");
            }
            else
            {
                return new ValidationResult(true,null);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;
namespace vdks.Helper
{
    class StringNumberValidationRule:ValidationRule
    {
         public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (((string)value).Length > 12) return new ValidationResult(false, "Введите 11-значный номер с +7 в формате \"+70000000000\"");
            Regex regexp = new Regex(@"^\+7\d{10}");
            Match match = regexp.Match((string)value);
            if (match.Length > 0) return new ValidationResult(true,null);
            else return new ValidationResult(false,"Введите 11-значный номер с +7 в формате \"+70000000000\"");
        }
    }
 }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UPE_ONS.Util
{
    class RequiredValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false, "Campo Obrigatório");

            return new ValidationResult(true, null);
        }
    }
}

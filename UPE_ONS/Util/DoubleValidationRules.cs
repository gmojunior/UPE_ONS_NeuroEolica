using System;
using System.Windows.Controls;

namespace UPE_ONS.Util
{
    class DoubleValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            double numReal = 0;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false, "Campo Obrigatório");

            try
            {
                numReal = Convert.ToDouble(value.ToString());

                if (numReal < 0)
                    return new ValidationResult(false, "Digite um valor maior que zero.");
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Por favor, digite um número real.");
            }

            return new ValidationResult(true, null);
        }
    }
}

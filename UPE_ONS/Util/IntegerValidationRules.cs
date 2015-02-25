using System;
using System.Windows.Controls;

namespace UPE_ONS.Util
{
    class IntegerValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int numNatural = 0;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false, "Campo Obrigatório");

            try
            {
                numNatural = Convert.ToInt32(value.ToString());

                if(numNatural < 0)
                    return new ValidationResult(false, "Digite um valor maior que zero.");
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Por favor, digite um valor inteiro.");
            }

            return new ValidationResult(true, null);
        }
    }
}

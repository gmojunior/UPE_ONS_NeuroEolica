using System;
using System.Windows.Controls;

namespace UPE_ONS.Util
{
    class StringValidationRules : ValidationRule
    {
        private const int MAX_SIZE = 1000;

        private int _max;

        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false, "Campo Obrigatório");

            if (value.ToString().Length > Max)
                return new ValidationResult(false, "O tamanho máximo desse campo é de " + Max + ".");

            return new ValidationResult(true, null);
        }
    }
}

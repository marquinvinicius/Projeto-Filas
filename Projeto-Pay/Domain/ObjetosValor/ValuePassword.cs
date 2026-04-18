using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ObjetosValor
{
    public record ValuePassword
    {
        public string Value { get; }

        private ValuePassword(string value)
        {
            Value = value;
        }
        public static ValuePassword Create(string value)
        {
            if (TryParse(value, out var result))
                return result;
            throw new ArgumentException("A senha deve conter pelo menos 8 caracteres, incluindo letras e números.");
        }

        public static bool TryParse(string value, out ValuePassword result)
        {
            if (!string.IsNullOrWhiteSpace(value) &&
                value.Length >= 6 &&
                value.Any(char.IsDigit) &&
                value.Any(c => !char.IsLetterOrDigit(c)))
            {
                result = new ValuePassword(value);
                return true;
            }
            result = default!;
            return false;
        }
        public override string ToString() => "*********";
    }
}

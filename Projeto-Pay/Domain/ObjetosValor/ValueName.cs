using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Domain.ObjetosValor
{
    public record ValueName
    {
        public string Value { get;}

        private ValueName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("O nome não pode ser vazio ou conter apenas espaços em branco.");
            var nomeLimpo = value.Trim();

            if (nomeLimpo.Length < 3)
                throw new ArgumentException("Nome muito curto");

            if (nomeLimpo.Any(char.IsDigit))
                throw new ArgumentException("O nome não pode conter números.");

            var txtInfo = CultureInfo.InvariantCulture.TextInfo;

            Value = txtInfo.ToTitleCase(nomeLimpo.ToLower());
        }
        public static ValueName Create(string value) => new(value);

        public static bool TryParse(string value, out ValueName result)
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Trim().Length >= 3 && !value.Any(char.IsDigit))
            {
                result = new ValueName(value);
                return true;
            }
            result = default;
            return false;
        }

        public static implicit operator string(ValueName nome) => nome.Value;
        public static implicit operator ValueName(string nome) => new(nome);

        public override string ToString() => Value;

    }
}

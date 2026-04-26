using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ObjetosValor
{
    public readonly record struct ValueEmail
    {
        public string Value { get;}

        internal ValueEmail(string value) => Value = value;

        public static bool TryParse(string value, out ValueEmail result)
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Contains("@") && value.Contains("."))
            {
                result = new ValueEmail(value.Trim().ToLower());
                return true;
            }
            result = default!;
            return false;
        }
        public static ValueEmail Create(string value)
        {
            if (TryParse(value, out var result))
                return result;
            throw new ArgumentException("Email inválido ao tentar criar ValueEmail.");
        }

        public override string ToString() => Value;

        public ValueEmail() { }
    }
}

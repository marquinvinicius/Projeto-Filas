using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ObjetosValor
{
    public readonly record struct ValueCount
    {
        public int Value { get; }

        private ValueCount(int value)
        {
            if (value < 0)
                throw new ArgumentException("O valor de contagem não pode ser negativo.");
            Value = value;
        }

        public static ValueCount Create(int value) => new(value);

        public static bool TryParse(int value, out ValueCount result)
        {
            if (value >= 0)
            {
                result = new ValueCount(value);
                return true;
            }
            result = default;
            return false;
        }

        public ValueCount Add(int amount) => new(Value + amount);

        public ValueCount Subtract(int amount)
        {
            var newValue = Value - amount;
            return new ValueCount(newValue < 0 ? 0 : newValue); 
        }

        public static implicit operator int(ValueCount count) => count.Value;

        public static explicit operator ValueCount(int value) => new(value);

        public override string ToString() => Value.ToString();

        public ValueCount() { }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ObjetosValor
{
    public  record ValueCpf
    {
        public string Value { get; }
 
        internal ValueCpf (string value) => Value = value;

        public static ValueCpf Create(string value)
        {
            if (TryParse(value, out var result))
                return result;

            throw new ArgumentException("CPF inválido ao tentar criar ValueCpf.");
        }

        public static bool TryParse(string value, out ValueCpf result)
        {
            if (!string.IsNullOrWhiteSpace(value) && Validar(value))
            {
                result = new ValueCpf(Limpar(value));
                return true;
            }

            result = default!; 
            return false;
        }

        private static string Limpar(string cpf) =>
            new string(cpf.Where(char.IsDigit).ToArray());

        private static bool Validar(string cpf)
        {
            string numeros = Limpar(cpf);

            if (numeros.Length != 11) return false;

            if (numeros.All(c => c == numeros[0])) return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = numeros[..9];
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto.ToString();

            return numeros.EndsWith(digito);
        }

        public static implicit operator string(ValueCpf valueCpf) => valueCpf.Value;
        public static explicit operator ValueCpf(string cpf) => new ValueCpf(cpf);
        public override string ToString() =>
        long.Parse(Value).ToString(@"000\.000\.000\-00");
        protected ValueCpf() { }

    }
}

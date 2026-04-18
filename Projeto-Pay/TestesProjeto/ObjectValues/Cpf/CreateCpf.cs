using Domain.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesProjeto.ObjectValues.Cpf
{
    public class UnitTest
    {
        private static ValueCpf CreateRandom()
        {
            var random = new Random();
            int[] cpf = new int[11];

            for (int i = 0; i < 9; i++)
                cpf[i] = random.Next(0, 10);

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += cpf[i] * (10 - i);
            int resto = soma % 11;
            cpf[9] = resto < 2 ? 0 : 11 - resto;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += cpf[i] * (11 - i);
            resto = soma % 11;
            cpf[10] = resto < 2 ? 0 : 11 - resto;

            return new ValueCpf(string.Join("", cpf));
        }
        [Fact]
        public void TestCreateCorrect()
        {
            var cpf = CreateRandom();
            Assert.NotNull(cpf.Value);
        }
        [Theory]
        [InlineData("11111111111")]
        [InlineData("12345678900")]
        [InlineData("123")]
        [InlineData("abc.def.ghi-jk")]
        public void TestUpdateCorrect(string value)
        {
            var resultado = ValueCpf.TryParse(value, out _);
            Assert.False(resultado);
        }
    }
}

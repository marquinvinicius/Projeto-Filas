using Domain.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesProjeto.Nome
{
    public class UnitTest
    {
        [Theory]
        [InlineData("João Silva")]
        [InlineData("Maria")]
        [InlineData("Ana Clara")]
        public void TestCreateCorrect(string value)
        {
            var nome = ValueName.Create(value);
            Assert.NotNull(nome.Value);
            Assert.Equal(value.Trim(), nome.Value);
        }
        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("Jo")]
        [InlineData("Jo3n")]
        public void TestCreateIncorrect(string value)
        {
            Assert.Throws<ArgumentException>(() => ValueName.Create(value));
        }

        [Theory]
        [InlineData("agnyn silva", "Agnyn Silva")]
        [InlineData("AGNYN", "Agnyn")]
        [InlineData("  rOrB  ", "Rorb")]
        public void Deve_Formatar_Nome_Com_Capitalize(string input, string esperado)
        {
            var nome = ValueName.Create(input);
            Assert.Equal(esperado, nome.Value);
        }
    }
}

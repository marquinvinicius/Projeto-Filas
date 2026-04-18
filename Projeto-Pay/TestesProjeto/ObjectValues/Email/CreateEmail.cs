using Domain.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesProjeto.ObjectValues.Email
{
    public class CreateEmail
    {
        [Fact]
        public void TestCreateCorrect()
        {
            var email = ValueEmail.Create("jubilin@gmail.com");
            Assert.NotNull(email);
        }

        [Theory]
        [InlineData("jubilin")]
        [InlineData("jubilin@")]
        [InlineData("jubilin.gmail")]
        public void TestCreateIncorrect(string value)
        {
            var resultado = ValueEmail.TryParse(value, out _);

            Assert.Throws<ArgumentException>(() => ValueEmail.Create(value));
        }
    }
}

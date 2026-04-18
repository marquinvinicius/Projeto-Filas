using Domain.ObjetosValor;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;


namespace TestesProjeto.ObjectValues.Senha
{
    public class CreateSenha
    {
        [Fact]
        public void TestCreateCorrect()
        {
            var senha = ValuePassword.Create("senha#123");
            senha.Should().NotBeNull();
            senha.Value.Should().Be("senha#123");
        }
        [Fact]
        public void TestCreateIncorrect_ShouldThrowException()
        {

            Action act = () => ValuePassword.Create("12345");
            act.Should().Throw<ArgumentException>()
                .WithMessage("A senha deve conter pelo menos 8 caracteres, incluindo letras e números.");
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("abcdef")]
        [InlineData("abc123")]
        public void TestCreateIncorrect_ShouldReturnFalse(string value)
        {
            var resultado = ValuePassword.TryParse(value, out _);
            resultado.Should().BeFalse();
        }
    }
}

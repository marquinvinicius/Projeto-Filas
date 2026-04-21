using Domain.Entidades;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesProjeto.Entidades
{
    public class TestUser
    {
        [Fact]
        public void TestCreateUserCorrect()
        {
            string name = "Jubilin";
            string email = "jubilin@gmail.com";
            string password = "Senh@123";

            bool result = User.Create(name, email, password, out var user, out var errorMessage);

            result.Should().BeTrue();
            user.Should().NotBeNull();
            errorMessage.Should().BeNullOrEmpty();

            user.Name.Value.Should().Be(name);
        }

        [Theory]
        [InlineData("", "email@valido.com", "senha123", "Nome inválido.")]
        public void Create_ComDadosInvalidos_DeveRetornarFalseEMensagemDeErro(
        string name, string email, string password, string expectedError)
        {
            var result = User.Create(name, email, password, out User user, out string errorMessage);

            result.Should().BeFalse();
            user.Should().BeNull();
            errorMessage.Should().Be(expectedError);
        }
    }

}

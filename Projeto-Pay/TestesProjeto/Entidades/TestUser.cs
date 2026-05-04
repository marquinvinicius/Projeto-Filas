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
            string cpf = "183.661.607-42";

            bool result = User.Create(name, email, password, cpf, out var user, out var errorMessage);

            result.Should().BeTrue();
            user.Should().NotBeNull();
            errorMessage.Should().BeNullOrEmpty();

            user.Name.Value.Should().Be(name);
        }

        [Theory]
        [InlineData("", "email@valido.com", "senha123", "183.661.607-42", "Nome inválido.")]
        [InlineData("Nome Válido", "emailinvalido", "senha123", "183.661.607-42", "Email inválido.")]
        [InlineData("Nome Válido", "email@valido.com", "", "183.661.607-42", "Senha inválida.")]
        [InlineData("Nome Válido", "email@valido.com", "senha123", "", "CPF inválido.")]
        public void Create_ComDadosInvalidos_DeveRetornarFalseEMensagemDeErro(
            string name, string email, string password, string cpf, string expectedError)
        {
            var result = User.Create(name, email, password, cpf, out User user, out string errorMessage);

            result.Should().BeFalse();
            user.Should().BeNull();
            errorMessage.Should().Be(expectedError);
        }
    }

}

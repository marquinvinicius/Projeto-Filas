
using Domain.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class User
    {
        private User(Guid id, ValueName name, ValueEmail email, ValuePassword password, ValueCpf cpf)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Cpf = cpf;
        }

        public Guid Id { get; private set; }

        public ValueName Name { get; private set; }

        public ValueEmail Email { get; private set; }

        public ValuePassword Password { get; private set; }

        public ValueCpf Cpf { get; private set; }
        public void UpdateName(ValueName name)
        {
            Name = name;
        }
        public void UpdateEmail(ValueEmail email)
        {
            Email = email;
        }
        public void UpdatePassword(ValuePassword password)
        {
            Password = password;
        }

        public static bool Create(string name, string email, string password,
            string cpf,out User user, out string errorMessage)
        {
            user = null;
            errorMessage = string.Empty;
            if (!ValueName.TryParse(name, out var parsedName))
            {
                errorMessage = "Nome inválido.";
                return false;
            }
            if (!ValueEmail.TryParse(email, out var parsedEmail))
            {
                errorMessage = "Email inválido.";
                return false;
            }
            if (!ValuePassword.TryParse(password, out var parsedPassword))
            {
                errorMessage = "Senha inválida.";
                return false;
            }
            if (!ValueCpf.TryParse(cpf, out var parsedCpf))
            {
                errorMessage = "CPF inválido.";
                return false;
            }
            user = new User(Guid.NewGuid(), parsedName, parsedEmail, parsedPassword, parsedCpf);
            return true;
        }
    }
}

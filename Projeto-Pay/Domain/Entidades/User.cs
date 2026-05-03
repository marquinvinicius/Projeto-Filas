
using Domain.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class User
    {
        private User(Guid id, ValueName name, ValueEmail email, ValuePassword password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public Guid Id { get; private set; }

        public ValueName Name { get; private set; }

        public ValueEmail Email { get; private set; }

        public ValuePassword Password { get; private set; }

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
            out User user, out string errorMessage)
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
            user = new User(Guid.NewGuid(), parsedName, parsedEmail, parsedPassword);
            return true;
        }
    }
}

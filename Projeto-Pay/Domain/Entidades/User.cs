using Domain.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class User
    {
        public Guid Id { get; private set; }

        public ValueName Name { get; private set; }

        public ValueEmail Email { get; private set; }

        public ValuePassword Password { get; private set; }



    }
}

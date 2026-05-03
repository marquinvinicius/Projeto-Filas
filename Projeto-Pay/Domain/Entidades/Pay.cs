using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Pay
    {
        public Guid Id { get; private set; }

        public User User { get; private set; }

        public Product Product { get; private set; }

        private Pay(Guid id, User user, Product product)
        {
            Id = id;
            User = user;
            Product = product;
        }

        public static bool Create(User user, Product product, out Pay pay, out string errorMessage)
        {
            pay = null;
            errorMessage = string.Empty;
            if (user == null)
            {
                errorMessage = "Usuário inválido.";
                return false;
            }
            if (product == null)
            {
                errorMessage = "Produto inválido.";
                return false;
            }
            pay = new Pay(Guid.NewGuid(), user, product);
            return true;
        }

        public void UpdateUser(User user)
        {
            User = user;
        }
        public void UpdateProduct(Product product)
        {
            Product = product;
        }
        public void UpdatePay(User user, Product product)
        {
            User = user;
            Product = product;
        }
        public void ClearPay()
        {
            User = null;
            Product = null;
        }

    }
}

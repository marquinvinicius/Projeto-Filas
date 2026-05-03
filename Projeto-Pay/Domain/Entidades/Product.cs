using Domain.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Product
    {
        public Guid Id { get; private set; }
        public ValueCount Count { get; private set; }
        public ValueName Name { get; private set; }
        private Product(Guid id, ValueCount count, ValueName name)
        {
            Id = id;
            Count = count;
            Name = name;
        }

        public void UpdateCount(ValueCount count) => Count = count;
        public void UpdateName(ValueName name) => Name = name;

        public static bool TryCreate(string name, int count, out Product? product, out string errorMessage)
        {
            product = null;
            errorMessage = string.Empty;

            if (!ValueName.TryParse(name, out var parsedName))
            {
                errorMessage = "Nome inválido.";
                return false;
            }

            if (!ValueCount.TryParse(count, out var parsedCount))
            {
                errorMessage = "Contagem inválida.";
                return false;
            }

            product = new Product(Guid.NewGuid(), parsedCount, parsedName);
            return true;
        }

        protected Product () { }
    }

}

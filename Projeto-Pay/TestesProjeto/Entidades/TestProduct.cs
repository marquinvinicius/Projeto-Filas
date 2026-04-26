using Domain.Entidades;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesProjeto.Entidades
{
    public class TestProduct
    {
        [Fact]
        public void Create_WithValidData_ShouldReturnProduct()
        {
            var success = Product.TryCreate("Poção", 10, out var product, out var error);

            success.Should().BeTrue();
            product.Should().NotBeNull();
            product!.Name.Value.Should().Be("Poção");
            error.Should().BeEmpty();
        }
    }
}

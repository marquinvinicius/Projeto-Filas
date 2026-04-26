using Domain.ObjetosValor;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesProjeto.ObjectValues.Count
{
    public class TestCount
    {
        [Fact]
        public void TestCreateCorrect()
        {
            var count = ValueCount.Create(5);

            int num = count;

            num.Should().Be(5);
            count.Value.Should().Be(5);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(100)]
        public void Create_WithValidValue_ShouldSucceed(int num)
        {
            var count = ValueCount.Create(num);
            count.Value.Should().Be(num);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-50)]
        public void Create_WithNegativeValue_ShouldThrowException(int num)
        {
            Action act = () => ValueCount.Create(num);

            act.Should().Throw<ArgumentException>()
               .WithMessage("O valor de contagem não pode ser negativo.");
        }

    }
}

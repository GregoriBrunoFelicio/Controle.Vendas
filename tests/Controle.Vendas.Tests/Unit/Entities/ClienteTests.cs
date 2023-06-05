using Controle.Vendas.Api.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Controle.Vendas.Tests.Unit.Entities
{
    public class ClienteTests
    {
        [Test]
        public void Deve_Calcular_A_Divida_Do_Cliente_Corretamente()
        {
            var compras = new List<Compra>
            {
                new() { Produto = new Produto { Preco = 10 } },
                new() { Produto = new Produto { Preco = 30 } }
            };

            var cliente = new Cliente
            {
                Compras = compras
            };

            cliente.TotalDivida.Should().Be(40);
        }

        [Test]
        public void Deve_Retornar_A_Divida_Como_Zero_Caso_Cliente_Nao_Tenha_Compras()
        {
            var cliente = new Cliente
            {
                Compras = null
            };

            cliente.TotalDivida.Should().Be(0);
        }
    }
}

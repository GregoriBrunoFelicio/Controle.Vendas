using System.Net;
using System.Net.Http.Json;
using Controle.Vendas.Api.Commands;
using Controle.Vendas.Api.Data.Repositories;
using Controle.Vendas.Api.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Controle.Vendas.Tests.Integration
{
    public class ClienteControllerTests : IntegrationTestBase
    {
        protected IClienteRepository ClienteRepository;
        protected ITipoClienteRepository TipoClienteRepository;

        [OneTimeSetUp]
        public new void SetUp()
        {
            ClienteRepository = new ClienteRepository(Context);
            TipoClienteRepository = new TipoClienteRepository(Context);
        }
    }

    public class PostCliente : ClienteControllerTests
    {
        private CriarClienteCommand cliente;

        [OneTimeSetUp]
        public new async Task SetUp()
        {
            var tipoCliente = new TipoCliente { Nome = "Programador" };
            await TipoClienteRepository.AddAsync(tipoCliente);
            cliente = new CriarClienteCommand("Gregori", "Felicio", tipoCliente.Id);
        }

        [Test]
        public async Task Deve_Retornar_Ok_Ao_Criar_Cliente()
        {
            var resultado = await Client.PostAsJsonAsync("/Cliente", cliente);
            resultado.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}

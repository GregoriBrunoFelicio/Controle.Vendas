using Controle.Vendas.Api.Data;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Controle.Vendas.Tests.Integration
{
    public class IntegrationTestBase
    {
        protected HttpClient Client = default!;
        protected ControleVendasContext Context = default!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var factory = new CustomWebApplicationFactory();
            Context = factory.Services.CreateScope().ServiceProvider.GetService<ControleVendasContext>()!;
            Client = factory.CreateClient();
        }
    }
}

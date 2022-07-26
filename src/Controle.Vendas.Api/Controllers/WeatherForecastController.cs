using Controle.Vendas.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Vendas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public Cliente Teste()
        {
            var compras = new List<Compra>
            {
                new()
                {
                    Id = 1,
                    Data = DateTime.Now,
                    Produto = new () { Nome = "X-tudo", Preco = 10, Id = 1 },
                },
                new()
                {
                   Id = 2,
                    Data = DateTime.Now,
                    Produto = new () { Nome = "Fanta", Preco = 10, Id = 2 },
                }
            };

            var cliente = new Cliente
            {
                Id = 1,
                Nome = "João",
                Sobrenome = "Silva",
                TipoCliente = new TipoCliente { Id = 1, Nome = "Caminhoneiro" },
                Conta = new Conta
                {
                    Compras = compras,
                    
                }
            };

            return cliente;
        }
    };
}
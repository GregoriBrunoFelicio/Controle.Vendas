using Controle.Vendas.Api.Commands;
using Controle.Vendas.Api.Data.Repositories;
using Controle.Vendas.Api.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Vendas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepository _compraRepository;

        public CompraController(ICompraRepository CompraRepository) => _compraRepository = CompraRepository;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarCompraCommand command)
        {
            try
            {
                var compra = new Compra()
                {
                    ClienteId = command.ClienteId,
                    ProdutoId = command.ProdutoId,
                    Data = DateTime.Now
                };
                await _compraRepository.Add(compra);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CriarCompraCommand command)
        {
            try
            {
                var compra = new Compra()
                {
                    ClienteId = command.ClienteId,
                    ProdutoId = command.ProdutoId,
                };

                await _compraRepository.Update(compra);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
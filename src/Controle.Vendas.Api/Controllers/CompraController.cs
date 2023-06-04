using Controle.Vendas.Api.Commands;
using Controle.Vendas.Api.Data.Repositories;
using Controle.Vendas.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Vendas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepository _compraRepository;

        public CompraController(ICompraRepository compraRepository) => _compraRepository = compraRepository;

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
                await _compraRepository.AddAsync(compra);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AtualizarCompraCommand command)
        {
            try
            {
                var compra = new Compra()
                {
                    Id = command.Id,
                    ClienteId = command.ClienteId,
                    ProdutoId = command.ProdutoId,
                };

                await _compraRepository.UpdateAsync(compra);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
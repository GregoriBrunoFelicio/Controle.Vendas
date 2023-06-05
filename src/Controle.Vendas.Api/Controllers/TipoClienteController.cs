using Controle.Vendas.Api.Data.Repositories;
using Controle.Vendas.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Vendas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoClienteController : ControllerBase
    {
        private readonly ITipoClienteRepository _tipoClienteRepository;

        public TipoClienteController(ITipoClienteRepository TipoClienteRepository) => _tipoClienteRepository = TipoClienteRepository;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TipoCliente tipoCliente)
        {
            try
            {
                await _tipoClienteRepository.AddAsync(tipoCliente);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TipoCliente tipoCliente)
        {
            try
            {
                await _tipoClienteRepository.UpdateAsync(tipoCliente);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tiposCliente = await _tipoClienteRepository.GetAllAsync();
                return Ok(tiposCliente);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
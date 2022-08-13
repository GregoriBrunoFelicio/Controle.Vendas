using Controle.Vendas.Api.Data.Repositories;
using Controle.Vendas.Api.Entidades;
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
                await _tipoClienteRepository.Add(tipoCliente);
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
                await _tipoClienteRepository.Update(tipoCliente);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }}
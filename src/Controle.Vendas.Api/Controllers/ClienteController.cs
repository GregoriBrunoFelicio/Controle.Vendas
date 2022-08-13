using Controle.Vendas.Api.Commands;
using Controle.Vendas.Api.Data.Repositories;
using Controle.Vendas.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Vendas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository ClienteRepository) => _clienteRepository = ClienteRepository;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriaClienteCommand command)
        {
            try
            {
                var cliente = new Cliente
                {
                    Nome = command.Nome,
                    Sobrenome = command.Sobrenome,
                    TipoClienteId = command.TipoClienteId
                };

                await _clienteRepository.Add(cliente);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Cliente cliente)
        {
            try
            {
                await _clienteRepository.Update(cliente);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
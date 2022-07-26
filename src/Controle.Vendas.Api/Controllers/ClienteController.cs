using Controle.Vendas.Api.Commands;
using Controle.Vendas.Api.Data.Repositories;
using Controle.Vendas.Api.Entidades;
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
        public async Task<IActionResult> Post([FromBody] CriarClienteCommand command)
        {
            try
            {
                var cliente = new Cliente()
                {
                    Nome = command.Nome,
                    Sobrenome = command.Sobrenome,
                    TipoClienteId = command.TipoClienteId,
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
        public async Task<IActionResult> Put([FromBody] AtualizarClienteCommand command)
        {
            try
            {
                var cliente = new Cliente()
                {
                    Id = command.Id,
                    Nome = command.Nome,
                    Sobrenome = command.Sobrenome,
                    TipoClienteId = command.TipoClienteId,
                };

                await _clienteRepository.Update(cliente);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("ComCompras")]
        public async Task<IEnumerable<Cliente>> ObterTodosPorMes() =>
             await _clienteRepository.ObterComCompras();

        [HttpGet()]
        public async Task<IEnumerable<Cliente>> ObterTodos() =>
              await _clienteRepository.ObterTodos();
    }
}
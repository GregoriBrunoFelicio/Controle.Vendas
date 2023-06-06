using Controle.Vendas.Api.Commands;
using Controle.Vendas.Api.Data.Repositories;
using Controle.Vendas.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Vendas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository) => _clienteRepository = clienteRepository;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarClienteCommand command)
        {
            try
            {
                var cliente = new Cliente
                {
                    Nome = command.Nome,
                    Sobrenome = command.Sobrenome,
                    TipoClienteId = command.TipoClienteId,
                };

                await _clienteRepository.AddAsync(cliente);
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
                var cliente = new Cliente
                {
                    Id = command.Id,
                    Nome = command.Nome,
                    Sobrenome = command.Sobrenome,
                    TipoClienteId = command.TipoClienteId,
                };

                await _clienteRepository.UpdateAsync(cliente);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }


        [HttpPut("Inativar/{id:int}")]
        public async Task<IActionResult> Inativar(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetByIdAsync(id);

                if (cliente is null) return NotFound("Cliente não encontrado");

                if (cliente.TotalDivida > 0)
                {
                    return BadRequest($"Cliente possui dívida em aberto no valor de {cliente.TotalDivida}");
                }

                await _clienteRepository.InativarAsync(cliente);

                return Ok();

            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }


        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetAll() =>
              await _clienteRepository.GetAllAsync();

        [HttpGet("ComDivida")]
        public async Task<IEnumerable<Cliente>> ComDivida() =>
              await _clienteRepository.ObterComDividaAsync();
    }
}
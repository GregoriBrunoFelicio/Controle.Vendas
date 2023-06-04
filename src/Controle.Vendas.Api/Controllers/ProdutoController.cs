using Controle.Vendas.Api.Commands;
using Controle.Vendas.Api.Data.Repositories;
using Controle.Vendas.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Vendas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository) => _produtoRepository = produtoRepository;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarProdutoCommand command)
        {
            try
            {
                var produto = new Produto
                {
                    Nome = command.Nome,
                    Preco = command.Preco,
                };

                await _produtoRepository.AddAsync(produto);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AtualizarProdutoCommand command)
        {
            try
            {
                var produto = new Produto()
                {
                    Id = command.Id,
                    Nome = command.Nome,
                    Preco = command.Preco,
                };

                await _produtoRepository.UpdateAsync(produto);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }}
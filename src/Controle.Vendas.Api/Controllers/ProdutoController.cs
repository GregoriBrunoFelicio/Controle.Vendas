using Controle.Vendas.Api.Data.Repositories;
using Controle.Vendas.Api.Entidades;
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
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            try
            {
                await _produtoRepository.Add(produto);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Produto produto)
        {
            try
            {
                await _produtoRepository.Update(produto);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }}
namespace Controle.Vendas.Api.Commands
{
    public record AtualizarProdutoCommand(int Id, string Nome, decimal Preco);
}

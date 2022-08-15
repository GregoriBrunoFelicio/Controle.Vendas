namespace Controle.Vendas.Api.Commands
{
    public record AtualizarClienteCommand(int Id, string Nome, string Sobrenome, int TipoClienteId);
}

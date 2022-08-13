namespace Controle.Vendas.Api.Commands
{
    public record CriarClienteCommand(string Nome, string Sobrenome, int TipoClienteId);
}

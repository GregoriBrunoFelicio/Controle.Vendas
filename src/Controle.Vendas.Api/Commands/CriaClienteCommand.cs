using Controle.Vendas.Api.Models;

namespace Controle.Vendas.Api.Commands
{
    public record CriaClienteCommand(string Nome, string Sobrenome, int TipoClienteId);
}

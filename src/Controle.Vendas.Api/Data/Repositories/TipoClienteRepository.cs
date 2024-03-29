﻿using Controle.Vendas.Api.Entities;

namespace Controle.Vendas.Api.Data.Repositories
{
    public interface ITipoClienteRepository: IRepository<TipoCliente>
    {
    }

    public class TipoClienteRepository : Repository<TipoCliente>, ITipoClienteRepository
    {
        public TipoClienteRepository(ControleVendasContext context) : base(context)
        {
        }
    }
}

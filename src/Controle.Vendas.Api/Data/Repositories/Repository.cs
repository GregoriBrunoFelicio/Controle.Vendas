using Controle.Vendas.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Controle.Vendas.Api.Data.Repositories
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }

    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected ControleVendasContext Context;
        protected DbSet<T> DbSet;

        public Repository(ControleVendasContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id) =>
            await DbSet.FirstOrDefaultAsync(x => x.Id == id);

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await DbSet.AsNoTracking().ToListAsync();

        public virtual async Task UpdateAsync(T entity)
        {
            var objFromDb = await DbSet.FindAsync(entity.Id);
            Context.Entry(objFromDb).CurrentValues.SetValues(entity);
            await Context.SaveChangesAsync();
        }
    }
}

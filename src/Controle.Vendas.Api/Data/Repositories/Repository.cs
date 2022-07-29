using Controle.Vendas.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Controle.Vendas.Api.Data.Repositories
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task Update(T entity);
        Task<T> Get(int id);
    }

    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected ControleVendasContext _context;
        protected DbSet<T> _dbSet;

        public Repository(ControleVendasContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(int id) =>
            await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public async Task Update(T entity)
        {
            var objFromDb = await _dbSet.FindAsync(entity.Id);
            _context.Entry(objFromDb).CurrentValues.SetValues(entity);
        }
    }
}

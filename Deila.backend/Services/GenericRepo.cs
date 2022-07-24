using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deila.backend.Services
{
    public class GenericRepo<TEntity, TContext> : IGenericRepo<TEntity>
    where TEntity : class
    where TContext : DbContext
    {
        protected readonly TContext Context;

        protected GenericRepo(TContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(TEntity model)
        {
            Context.Set<TEntity>().Add(model);
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public bool HasChanges()
        {
            return Context.ChangeTracker.HasChanges();
        }

        public void Remove(TEntity model)
        {
            Context.Set<TEntity>().Remove(model);
            Context.SaveChanges();
        }
        public async Task<bool> Update(TEntity model)
        {
            Context.Entry(model).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}

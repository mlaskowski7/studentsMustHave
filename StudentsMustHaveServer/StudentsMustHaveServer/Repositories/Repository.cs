using Microsoft.EntityFrameworkCore;
using StudentsMustHaveServer.Data;
using StudentsMustHaveServer.Repositories.Interfaces;

namespace StudentsMustHaveServer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly StudentsDbContext context;

        public Repository(StudentsDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await context.Set<T>().FindAsync(id);
            if (result == null)
            {
                throw new ArgumentException("student with provided id is not in database");
            }
            
            return result;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
    
}

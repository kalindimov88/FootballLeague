using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Data.Repositories
{
    public class Repository : IRepository
    {
        private ApplicationDbContext _context;

        public Repository(ApplicationDbContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
        }

        public async Task<T> GetByIdAsync<T>(object id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> Set<T>() where T : class
        {
            return _context.Set<T>().AsQueryable<T>();
        }

        public IQueryable<T> SetNoTracking<T>(params string[] includes) where T : class
        {
            var query = _context.Set<T>().AsNoTracking();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public async Task AddAsync<T>(T obj) where T : class
        {
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T obj) where T : class
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T obj) where T : class
        {
            _context.Entry(obj).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

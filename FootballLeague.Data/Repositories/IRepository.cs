using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Repositories
{
    public interface IRepository
    {
        public Task<T> GetByIdAsync<T>(object id) where T : class;

        IQueryable<T> Set<T>() where T : class;

        IQueryable<T> SetNoTracking<T>(params string[] includes) where T : class;

        Task AddAsync<T>(T obj) where T : class;

        Task UpdateAsync<T>(T obj) where T : class;

        Task DeleteAsync<T>(T obj) where T : class;
    }
}

using DAL.Repository.IRepository;
using DAL.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        //private readonly dbcontext dbContext;

        //public Repository(dbcontext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}
        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
    
    
}

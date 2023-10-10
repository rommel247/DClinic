using DClinic.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DClinic.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace DClinic.Domain.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DclinicContext _dbcontext;
        public GenericRepository(DclinicContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
    
        public async Task AddAsync(T entity)
        {
            await _dbcontext.Set<T>().AddAsync(entity);
        }        

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> GetbyIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
             _dbcontext.Set<T>().Update(entity);
        }
    }
}

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

        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
            {
                var msg = $"{nameof(entity)} must not be null";
                throw new ArgumentNullException(msg);
            }

            try
            {
                _dbcontext.Add(entity);
                await _dbcontext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                var msg = $"{nameof(entity)} could not be saved:  {ex.Message}";
                throw new Exception(ex.Message);
            }


        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> GetbyIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                var msg = $"{nameof(entity)} must not be null";
                throw new ArgumentNullException(msg);
            }
            try
            {
                _dbcontext.Set<T>().Update(entity);
                await _dbcontext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                var msg = $"{nameof(entity)} could not be updated:  {ex.Message}";
                throw new Exception(ex.Message);
            }        
        }
    }
}

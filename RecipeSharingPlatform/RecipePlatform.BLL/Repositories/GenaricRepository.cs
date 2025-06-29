using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipePlatform.BLL.Interfaces;
using RecipePlatform.DAL.Context;
using RecipePlatform.Models.Models;

namespace RecipePlatform.BLL.Repositories
{
    public class GenaricRepository<T> : IGenaricRepository <T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;


        public GenaricRepository(ApplicationDbContext context)

        {
            _context = context;

        }

        public async Task<T> Add(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task Delete(object id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
             
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(object id)
        {      
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsQueryable();

        }

        public async Task<T> Update(T entity)
        {
           _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
       
    }
}

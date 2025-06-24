using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public T Add(T entity)
        => _context.Set<T>().Add(entity).Entity;
        public T Delete(int id)
        => _context.Set<T>().Remove(GetById(id)).Entity;

        public IEnumerable<T> GetAll()
        => _context.Set<T>().ToList();

        public T GetById(int id)
        => _context.Set<T>().Find(id);

        public T Update(T entity)
        => _context.Set<T>().Update(entity).Entity;
    }
}

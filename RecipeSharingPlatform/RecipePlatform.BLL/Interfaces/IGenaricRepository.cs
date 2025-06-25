using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.DAL.Entitys;
using RecipePlatform.Models.Models;

namespace RecipePlatform.BLL.Interfaces
{
    public interface IGenaricRepository<T> where T : BaseEntity
    {
        Task<T> GetById(object id);
        Task <IEnumerable<T>> GetAll();
        Task <T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(object id);
        
        IQueryable<T> GetQueryable();

    }
}

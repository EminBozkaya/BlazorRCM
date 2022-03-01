using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseInfrastructure
{
    public interface IRepository<T> where T : BaseDomain, new()
    {

        Task<ICollection<T>> GetAll(Expression<Func<T, bool>>? filter = null, params string[] includeList);

        Task<T> Get(Expression<Func<T, bool>> filter, params string[] includeList);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(T entity);

    }
}

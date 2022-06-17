using RCMServerData.BaseModel;
using System.Linq.Expressions;

namespace BlazorRCM.Server.Services.BaseServices.BaseInfrastructure
{
    public interface IRepository<T> where T : Base, new()
    {

        Task<ICollection<T>> GetAll(Expression<Func<T, bool>>? filter = null, params string[] includeList);

        Task<T> Get(Expression<Func<T, bool>> filter, params string[] includeList);

        Task<T> Create(T entity);

        //T Update(T entity);
        Task<T> Update(T entity);

        Task<bool> Delete(T entity);
        Task DeleteByFilter(Expression<Func<T, bool>> filter);

    }
}

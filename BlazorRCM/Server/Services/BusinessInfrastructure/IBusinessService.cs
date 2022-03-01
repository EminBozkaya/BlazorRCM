using System.Linq.Expressions;

namespace BlazorRCM.Server.Services.BusinessInfrastructure
{
    public interface IBusinessService<TEntity>
    {
        //ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

        Task<ICollection<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null, params string[] includeList);

        //TEntity Get(Expression<Func<TEntity, bool>> filter=null);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter, params string[] includeList);

        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);


        //TEntity GetById(int id, params string[] includeList);
        //void Delete(int id);
    }
}

using Core.BaseInfrastructure;
using Core.Model;
using System.Linq.Expressions;

namespace BlazorRCM.Server.Services.BusinessInfrastructure
{
    public class BusinessService<TEntity> : IBusinessService<TEntity>
    where TEntity : BaseDomain, new()
    {
        IRepository<TEntity> _repo;

        public BusinessService(IRepository<TEntity> repo)
        {
            _repo = repo;
        }

        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter, params string[] includeList)
        {
            try
            {
                return await _repo.Get(filter, includeList);
            }
            
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null, params string[] includeList)
        {
            try
            {
                return await _repo.GetAll(filter, includeList);
            }
            
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {

            //Type type = Type.GetType("RCM.Business.ValidationRules.FluentValidation.Domain." + entity.GetType().Name + "Validator");

            //AbstractValidator<TEntity> validatorObj = Activator.CreateInstance(type) as AbstractValidator<TEntity>;

            try
            {
                //ValidationTool<TEntity>.Validate(validatorObj, entity);

                return await _repo.Create(entity);
            }
            
            catch (Exception)
            {
                throw;
            }

            //return _repo.Insert(entity);

        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            //Type type = Type.GetType("RCM.Business.ValidationRules.FluentValidation.Domain." + entity.GetType().Name + "Validator");

            //AbstractValidator<TEntity> validatorObj = Activator.CreateInstance(type) as AbstractValidator<TEntity>;

            try
            {
                //ValidationTool<TEntity>.Validate(validatorObj, entity);
                return await _repo.Update(entity);
            }
            
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task Delete(TEntity entity)
        {
            try
            {
               await _repo.Delete(entity);
            }
            
            catch (Exception)
            {
                throw;
            }
        }

    }

}

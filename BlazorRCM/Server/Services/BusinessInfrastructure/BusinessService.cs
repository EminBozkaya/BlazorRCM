using Core.BaseInfrastructure;
using Core.Model;
using System.Linq.Expressions;

namespace BlazorRCM.Server.Services.BusinessInfrastructure
{
    public class BusinessService<TEntityDTO> : IBusinessService<TEntityDTO>
    where TEntityDTO : BaseDTO, new()
    {
        IRepository<TEntityDTO> _repo;

        public BusinessService(IRepository<TEntityDTO> repo)
        {
            _repo = repo;
        }

        public virtual async Task<TEntityDTO> Get(Expression<Func<TEntityDTO, bool>> filter, params string[] includeList)
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

        public async Task<ICollection<TEntityDTO>> GetAll(Expression<Func<TEntityDTO, bool>>? filter = null, params string[] includeList)
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

        public virtual async Task<TEntityDTO> Create(TEntityDTO entity)
        {

            //Type type = Type.GetType("RCM.Business.ValidationRules.FluentValidation.Domain." + entity.GetType().Name + "Validator");

            //AbstractValidator<TEntityDTO> validatorObj = Activator.CreateInstance(type) as AbstractValidator<TEntityDTO>;

            try
            {
                //ValidationTool<TEntityDTO>.Validate(validatorObj, entity);

                return await _repo.Create(entity);
            }
            
            catch (Exception)
            {
                throw;
            }

            //return _repo.Insert(entity);

        }

        public virtual async Task<TEntityDTO> Update(TEntityDTO entity)
        {
            //Type type = Type.GetType("RCM.Business.ValidationRules.FluentValidation.Domain." + entity.GetType().Name + "Validator");

            //AbstractValidator<TEntityDTO> validatorObj = Activator.CreateInstance(type) as AbstractValidator<TEntityDTO>;

            try
            {
                //ValidationTool<TEntityDTO>.Validate(validatorObj, entity);
                return await _repo.Update(entity);
            }
            
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task Delete(TEntityDTO entity)
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

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using RCMServerData.BaseModels;
using BlazorRCM.Shared.DTOs.BaseDTOs;
using BlazorRCM.Server.Services.BaseServices.BaseInfrastructure;
using FluentValidation;
using BlazorRCM.Shared.Utils;
using BlazorRCM.Shared.ValidationRules.FluentValidation.DTOs.ModelDTOs;
//using System.Data;

namespace BlazorRCM.Server.Services.BaseServices.BaseService.EF
{
    public class EfRepositoryBase<TContext, TEntity, TEntityDTO> : IRepository<TEntityDTO>
        where TEntity : BaseDomain, new()
        where TContext : DbContext, new()
        where TEntityDTO : BaseDTO, new()
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public EfRepositoryBase(IMapper Mapper, IConfiguration Configuration)
        {
            mapper = Mapper;
            configuration = Configuration;

        }

        public async Task<ICollection<TEntityDTO>> GetAll(Expression<Func<TEntityDTO, bool>>? filter = null, params string[] includeList)
        {
            try
            {

                using TContext ctx = new TContext();
                var query = ctx.Set<TEntity>().AsQueryable();
                //DbSet<TEntity>? query = ctx.Set<TEntity>();
                //IQueryable<TEntity> query = ctx.Set<TEntity>();

                //query.Include("User");
                //includeList = new[] { "Branch", "AuthorityType" };


                //TEntity ety = query.AsEnumerable().FirstOrDefault(x => x.GetType().GetProperty("Id")!.GetValue(x)!.ToString()! == "4")!;

                //List<TEntity> entities = await query.ToListAsync();
                //Type type = Type.GetType("RCMServerData.Models." + includeList[0].GetType().Name);
                //if (includeList != null)
                //{
                //    query.Include(includeList[0]);

                //}
                //List<TEntity> lists = query.ToList();

                //IQueryable<TEntityDTO> queryDTO = query.ProjectTo<TEntityDTO>(mapper.ConfigurationProvider);
                //IQueryable<TEntity> query = filter == null
                //    ? ctx.Set<TEntity>()
                //    : ctx.Set<TEntity>().Where(filter);

                //TEntity entity = new TEntity();
                //Type type = Type.GetType("BlazorRCM.Shared.DTOs." + entity.GetType().Name + "DTO")!;

                //IQueryable<TEntityDTO> queryDTO = filter == null
                //    ? ctx.Set<TEntity>().ProjectTo<TEntityDTO>(mapper.ConfigurationProvider)
                //    : ctx.Set<TEntity>().ProjectTo<TEntityDTO>(mapper.ConfigurationProvider).Where(filter);

                //--------------------------------------------


                if (includeList != null)
                {
                    for (int i = 0; i < includeList.Length; i++)
                    {
                        query = query!.Include(includeList[i]);
                    }
                }

                IQueryable<TEntityDTO> queryDTO = filter == null
                    ? query.ProjectTo<TEntityDTO>(mapper.ConfigurationProvider)
                    : query.ProjectTo<TEntityDTO>(mapper.ConfigurationProvider).Where(filter);


                //---------------------------------------------


                //IQueryable<TEntity> query = filter == null
                //    ? ctx.Set<TEntity>().ProjectTo<TEntityDTO>(mapper.ConfigurationProvider)
                //    : ctx.Set<TEntity>().Where(filter).ProjectTo<TEntityDTO>(mapper.ConfigurationProvider);

                //                _mapper.ProjectTo<SomeViewModel>(dbContext.SomeEntity)
                //.ToListAsync();



                List<TEntityDTO> list = await queryDTO.ToListAsync();
                return list;
                //return await query.ToListAsync();

            }

            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntityDTO> Get(Expression<Func<TEntityDTO, bool>> filter, params string[] includeList)
        {
            try
            {
                using TContext ctx = new TContext();
                var query = ctx.Set<TEntity>().AsQueryable();

                ////IQueryable<TEntityDTO> query = ctx.Set<TEntity>().ProjectTo<TEntityDTO>(mapper.ConfigurationProvider);

                //if (includeList != null)
                //{
                //    for (int i = 0; i < includeList.Length; i++)
                //    {
                //        query = query.Include(includeList[i]);
                //    }
                //}

                //IQueryable<TEntityDTO> queryDTO = query.ProjectTo<TEntityDTO>(mapper.ConfigurationProvider);

                //TEntityDTO? dto = filter==null
                //    ? query as TEntityDTO
                //    : await queryDTO.FirstOrDefaultAsync(filter);
                //if (dto == null)
                //    throw new Exception("Kritere uyan kayıt bulunamadı");

                //return dto;





                //IQueryable<TEntity> query = ctx.Set<TEntity>();



                if (includeList != null)
                {
                    for (int i = 0; i < includeList.Length; i++)
                    {
                        query = query.Include(includeList[i]);
                    }
                }

                IQueryable<TEntityDTO> queryDTO = query.ProjectTo<TEntityDTO>(mapper.ConfigurationProvider);
                //IQueryable<TEntityDTO> query = ctx.Set<TEntity>().ProjectTo<TEntityDTO>(mapper.ConfigurationProvider);

                TEntityDTO? dto = await queryDTO.FirstOrDefaultAsync(filter);
                if (dto == null)
                    throw new Exception("Kritere uyan kayıt bulunamadı");

                return dto;
            }

            catch (Exception)
            {
                throw;
            }
        }


        public async Task<TEntityDTO> Create(TEntityDTO entity)
        {
            try
            {
                //*******validation for TEntityDTO entity**************
                string? validatorName = "BlazorRCM.Shared.ValidationRules.FluentValidation.DTOs.ModelDTOs." + entity.GetType().Name + "Validator";
                Type? validatorType = Type.GetType($"{validatorName}, BlazorRCM.Shared");

                if (validatorType != null)
                {
                    AbstractValidator<TEntityDTO>? validatorObj = Activator.CreateInstance(validatorType!) as AbstractValidator<TEntityDTO>;
                    if (validatorObj != null)
                        FluentValidationTool<TEntityDTO>.Validate(validatorObj, entity);
                }
                //*******************************************

                using TContext ctx = new TContext();


                TEntity? Entity = mapper.Map<TEntity>(entity);

                //*******validation for TEntity Entity(maybe later)**************


                await ctx.Set<TEntity>().AddAsync(Entity);
                //TEntity? addedEntity = (await ctx.Set<TEntity>().AddAsync(Entity)) as TEntity;
                await ctx.SaveChangesAsync();

                TEntityDTO addedDTOEntity = mapper.Map<TEntityDTO>(Entity);

                return addedDTOEntity;
            }

            catch (Exception)
            {
                throw;
            }
        }

        
        public async Task<TEntityDTO> Update(TEntityDTO entity)
        {
            try
            {
                //*******validation for TEntity entity**************
                string? validatorName = "BlazorRCM.Shared.ValidationRules.FluentValidation.DTOs.ModelDTOs." + entity.GetType().Name + "Validator";
                Type? validatorType = Type.GetType($"{validatorName}, BlazorRCM.Shared");

                if (validatorType != null) 
                {
                    AbstractValidator<TEntityDTO>? validatorObj = Activator.CreateInstance(validatorType!) as AbstractValidator<TEntityDTO>;
                    if (validatorObj != null)
                        FluentValidationTool<TEntityDTO>.Validate(validatorObj, entity);
                }
                
                //*******************************************

                using TContext ctx = new();

                IQueryable<TEntity> query = ctx.Set<TEntity>();

                Type type = entity.GetType();
                Type typeDB = typeof(TEntity);

                var prop = typeDB.GetProperty("ModifiedTime");
                //var prop = typeDB.GetProperties().FirstOrDefault(p => p.PropertyType.Name == "ModifiedTime")!.Name;

                var EntityType = type.GetProperty("Id")!;
                

                if (EntityType == null)//for without Id records(unnesessary, not working , because savechanges doesnt work pk less)
                {
                    TEntity? Entity = mapper.Map<TEntity>(entity);
                    if (Entity == null) throw new Exception("Kayıt bulunamadı");
                    ctx.Set<TEntity>().Attach(Entity);
                    ctx.Entry(Entity!).State = EntityState.Modified;

                    if(prop!=null)
                        Entity!.GetType().GetProperty("ModifiedTime")!.SetValue(Entity, DateTime.Now, null);

                    ctx.Set<TEntity>().Update(Entity!);
                    int updates = await ctx.SaveChangesAsync();
                    ctx.Entry(Entity!).State = EntityState.Detached;
                    TEntityDTO updatedDTOEntity = mapper.Map<TEntityDTO>(Entity);
                    return updatedDTOEntity;
                }
                else
                {
                    var id = EntityType.GetValue(entity)!.ToString();
                    TEntity? Entity = query.AsEnumerable().FirstOrDefault(x => x.GetType().GetProperty("Id")!.GetValue(x)!.ToString() == id);

                    if (Entity == null) throw new Exception("Kayıt bulunamadı");

                    ctx.Entry(Entity!).State = EntityState.Detached;

                    //Entity!.GetType().GetProperty("UId")!.SetValue(Entity, Convert.ToInt16(7), null);
                    //Entity!.GetType().GetProperty("BId")!.SetValue(Entity, Convert.ToInt16(3), null);
                    //Entity!.GetType().GetProperty("ATId")!.SetValue(Entity, Convert.ToInt16(3), null);

                    //var transaction = await ctx.Database.BeginTransactionAsync(IsolationLevel.Serializable);
                    Entity = mapper.Map<TEntity>(entity);
                    ctx.Set<TEntity>().Attach(Entity!);
                    ctx.Entry(Entity!).State = EntityState.Modified;

                    if (prop != null)
                        Entity!.GetType().GetProperty("ModifiedTime")!.SetValue(Entity, DateTime.Now, null);

                    ctx.Set<TEntity>().Update(Entity!);
                    //bool hasChanges = ctx.ChangeTracker.HasChanges();
                    //var hasTransaction = ctx.Database.CurrentTransaction != null;
                    int updates = await ctx.SaveChangesAsync();
                    ctx.Entry(Entity!).State = EntityState.Detached;
                    TEntityDTO updatedDTOEntity = mapper.Map<TEntityDTO>(Entity);
                    return updatedDTOEntity;
                }
            }

            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> Delete(TEntityDTO entity)
        {
            try
            {
                using TContext ctx = new();

                IQueryable<TEntity> query = ctx.Set<TEntity>();
                //TEntity Entity = new();

                Type type = entity.GetType();
                var entityType = type.GetProperty("Id");
                

                if (entityType == null)//for without Id records
                {
                    TEntity? Entity = mapper.Map<TEntity>(entity);
                    if (Entity == null) throw new Exception("Kayıt bulunamadı");
                    if (ctx.Entry(Entity).State == EntityState.Detached)
                    ctx.Set<TEntity>().Attach(Entity);
                    ctx.Set<TEntity>().Remove(Entity);
                    int result = await ctx.SaveChangesAsync();
                    ctx.Entry(Entity!).State = EntityState.Detached;
                    return result > 0;
                }
                else 
                {
                    string? id = entityType!.GetValue(entity)!.ToString();
                    TEntity? Entity = query.AsEnumerable().FirstOrDefault(x => x.GetType().GetProperty("Id")!.GetValue(x)!.ToString() == id)!;
                    if (Entity == null) throw new Exception("Kayıt bulunamadı");
                    ctx.Entry(Entity!).State = EntityState.Detached;
                    ctx.Set<TEntity>().Attach(Entity);
                    ctx.Set<TEntity>().Remove(Entity);
                    int result = await ctx.SaveChangesAsync();
                    return result > 0;
                }
            }

            catch (Exception)
            {
                throw;
            }
        }


        async Task IRepository<TEntityDTO>.DeleteByFilter(Expression<Func<TEntityDTO, bool>> filter)
        {
            using TContext ctx = new();
            var query = ctx.Set<TEntity>().AsQueryable();
            IQueryable<TEntityDTO> queryDTO = filter == null
                    ? query.ProjectTo<TEntityDTO>(mapper.ConfigurationProvider)
                    : query.ProjectTo<TEntityDTO>(mapper.ConfigurationProvider).Where(filter);
            if (queryDTO != null)
            {
                foreach (TEntityDTO dto in queryDTO)
                {
                    bool result = await Delete(dto);
                }
            }
            
        }

        //Task IRepository<TEntityDTO>.DeleteByFilter(Expression<Func<TEntityDTO, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //void IRepository<TEntityDTO>.DeleteByFilter(Expression<Func<TEntityDTO, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

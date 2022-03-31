using Core.BaseInfrastructure;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using AutoMapper.QueryableExtensions;

namespace Core.BaseService.EF
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

                using (TContext ctx = new TContext())
                {
                    IQueryable<TEntity> query = ctx.Set<TEntity>();

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
                            query = query.Include(includeList[i]);
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



                    List<TEntityDTO> list= await queryDTO.ToListAsync();
                    return list;
                    //return await query.ToListAsync();

                }
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
                using (TContext ctx = new TContext())
                {
                    //IQueryable<TEntity> query = ctx.Set<TEntity>();

                    IQueryable<TEntityDTO> query = ctx.Set<TEntity>().ProjectTo<TEntityDTO>(mapper.ConfigurationProvider);

                    if (includeList != null)
                    {
                        for (int i = 0; i < includeList.Length; i++)
                        {
                            query = query.Include(includeList[i]);
                        }
                    }

                    TEntityDTO? dto = await query.FirstOrDefaultAsync(filter);
                    if (dto == null)
                        throw new Exception("Kritere uyan kayıt bulunamadı");

                    return dto;
                }
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
                using (TContext ctx = new TContext())
                {

                    //TEntity? addedEntity = (await ctx.AddAsync(entity)) as TEntity;
                    //await ctx.SaveChangesAsync();

                    //return addedEntity;



                    //TEntity? addedEntity = (await ctx.Set<TEntity>().AddAsync(entity)) as TEntity;
                    //await ctx.SaveChangesAsync();

                    TEntity? Entity = mapper.Map<TEntity>(entity);
                    await ctx.Set<TEntity>().AddAsync(Entity);
                    //TEntity? addedEntity = (await ctx.Set<TEntity>().AddAsync(Entity)) as TEntity;
                    await ctx.SaveChangesAsync();

                    TEntityDTO addedDTOEntity = mapper.Map<TEntityDTO>(Entity);

                    return addedDTOEntity;
                }
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
                using (TContext ctx = new TContext())
                {
                    TEntity? Entity = mapper.Map<TEntity>(entity);
                    ctx.Set<TEntity>().Attach(Entity);
                    ctx.Entry(Entity).State = EntityState.Modified;
                    await ctx.SaveChangesAsync();

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
                using (TContext ctx = new TContext())
                {
                    TEntity? Entity = mapper.Map<TEntity>(entity);

                    if (ctx.Entry(Entity).State == EntityState.Detached)
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

    }
}

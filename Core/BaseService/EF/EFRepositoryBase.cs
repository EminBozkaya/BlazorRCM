using Core.BaseInfrastructure;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseService.EF
{
    public class EfRepositoryBase<TContext, TEntity> : IRepository<TEntity>
        where TEntity : BaseDomain, new()
        where TContext : DbContext, new()
    {

        public async Task<ICollection<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null, params string[] includeList)
        {
            try
            {

                using (TContext ctx = new TContext())
                {
                    IQueryable<TEntity> query = filter == null
                        ? ctx.Set<TEntity>()
                        : ctx.Set<TEntity>().Where(filter);

                    if (includeList != null)
                    {
                        for (int i = 0; i < includeList.Length; i++)
                        {
                            query = query.Include(includeList[i]);
                        }
                    }

                    return await query.ToListAsync();
                }
            }

            catch (Exception)
            {
                throw;
            }
        }


        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter, params string[] includeList)
        {
            try
            {
                using (TContext ctx = new TContext())
                {
                    IQueryable<TEntity> query = ctx.Set<TEntity>();

                    if (includeList != null)
                    {
                        for (int i = 0; i < includeList.Length; i++)
                        {
                            query = query.Include(includeList[i]);
                        }
                    }

                    return await query.FirstOrDefaultAsync(filter);
                }
            }

            catch (Exception)
            {
                throw;
            }
        }


        public async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                using (TContext ctx = new TContext())
                {

                    //TEntity? addedEntity = (await ctx.AddAsync(entity)) as TEntity;
                    //await ctx.SaveChangesAsync();

                    //return addedEntity;


                    TEntity? addedEntity = (await ctx.Set<TEntity>().AddAsync(entity)) as TEntity;
                    await ctx.SaveChangesAsync();

                    return addedEntity;
                }
            }

            catch (Exception)
            {
                throw;
            }
        }


        public async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                using (TContext ctx = new TContext())
                {
                    ctx.Set<TEntity>().Attach(entity);
                    ctx.Entry(entity).State = EntityState.Modified;
                    await ctx.SaveChangesAsync();

                    return entity;
                }
            }

            catch (Exception)
            {
                throw;
            }
        }


        public async Task Delete(TEntity entity)
        {
            try
            {
                using (TContext ctx = new TContext())
                {
                    if (ctx.Entry(entity).State == EntityState.Detached)
                        ctx.Set<TEntity>().Attach(entity);

                    ctx.Set<TEntity>().Remove(entity);
                    await ctx.SaveChangesAsync();
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

    }
}

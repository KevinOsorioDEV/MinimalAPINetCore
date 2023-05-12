using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BeerapiNet7._0
{
    public class ApiUtilities
    {
        public static async Task<T> CreatedEntityAsync<T>(T entity, DbContext context) where T : class
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public static async Task<List<TDto>> GetEntityAsync<TDto, TEntity> (DbContext context, IMapper mapper) where TEntity : class
        {
            var entities = await context.Set<TEntity>().ToListAsync();

            var dtoList = mapper.Map<List<TDto>>(entities);


            return dtoList;
        }
    }
}

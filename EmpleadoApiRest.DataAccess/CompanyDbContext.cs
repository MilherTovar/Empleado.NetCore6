using EmpleadoApiRest.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EmpleadoApiRest.DataAccess
{
    public class CompanyDbContext<T> : ICompanyDbContext<T> where T:class,IEntity
    {
        DbSet<T> _items;
        ApiDbContext _ctx;

        public CompanyDbContext(ApiDbContext ctx)
        {
            _ctx = ctx;
            _items = ctx.Set<T>();
        }

        public T GetById(int id)
        {
            return _items.Where(i => i.Id.Equals(id)).FirstOrDefault();
        }

        public T save(T entity)
        {
            _items.Add(entity);
            _ctx.SaveChanges();
            return entity;
        }
    }
}
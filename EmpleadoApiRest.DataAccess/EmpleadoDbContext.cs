using EmpleadoApiRest.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoApiRest.DataAccess
{
    public class EmpleadoDbContext<T> : IEmpleadoDbContext<T> where T : class, IEntity
    {
        DbSet<T> _items;
        ApiDbContext _ctx;
        public EmpleadoDbContext(ApiDbContext ctx)
        {
            _ctx = ctx;
            _items=ctx.Set<T>();
        }
        public void Delete(int id)
        {
            var item = _items.Find(id);
            if (item != null)
            {
                _items.Remove(item);
                _ctx.SaveChanges();
            }
        }

        public IList<T> GetAll()
        {
            return _items.ToList();
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

        public T Update(T entity)
        {
            var _entity = _items.Find(entity.Id);
            if (_entity != null)
            {
                _ctx.Entry(entity).CurrentValues.SetValues(entity);
                _ctx.SaveChanges();
            }
            return entity;
        }
    }
}

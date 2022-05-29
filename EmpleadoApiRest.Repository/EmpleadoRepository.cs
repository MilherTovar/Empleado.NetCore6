using EmpleadoApiRest.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoApiRest.Repository
{
    public interface IEmpleadoRepository<T> : EmpleadoICrud<T> { }
    public class EmpleadoRepository<T> : IEmpleadoRepository<T> where T : IEntity
    {
        IEmpleadoDbContext<T> _ctx;
        public EmpleadoRepository(IEmpleadoDbContext<T> ctx)
        {
            _ctx = ctx;
        }

        public void Delete(int id)
        {
            _ctx.Delete(id);
        }

        public IList<T> GetAll()
        {
            return _ctx.GetAll();
        }

        public T GetById(int id)
        {
            return _ctx.GetById(id);
        }

        public T save(T entity)
        {
            return _ctx.save(entity);
        }

        public T Update(T entity)
        {
            return _ctx.Update(entity);
        }
    }
}

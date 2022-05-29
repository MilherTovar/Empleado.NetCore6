using EmpleadoApiRest.Abstractions;
using EmpleadoApiRest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoApiRest.Application   
{
    public interface IEmpleadoApplication<T> : EmpleadoICrud<T> { }
    public class EmpleadoApplication<T> : IEmpleadoApplication<T> where T : IEntity
    {
        IEmpleadoRepository<T> _repository;
        public EmpleadoApplication(IEmpleadoRepository<T> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public T save(T entity)
        {
            return _repository.save(entity);
        }

        public T Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}

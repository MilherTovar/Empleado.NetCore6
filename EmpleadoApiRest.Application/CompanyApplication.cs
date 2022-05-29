using EmpleadoApiRest.Abstractions;
using EmpleadoApiRest.Repository;

namespace EmpleadoApiRest.Application
{
    public interface ICompanyApplication<T> : CompanyICrud<T> { }
    public class CompanyApplication<T> : ICompanyApplication<T> where T : IEntity
    {
        ICompanyRepository<T> _repository;
        public CompanyApplication(ICompanyRepository<T> repository)
        {
            _repository = repository;
        }
        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public T save(T entity)
        {
            return _repository.save(entity);
        }
    }
}
using EmpleadoApiRest.Abstractions;

namespace EmpleadoApiRest.Repository
{
    public interface ICompanyRepository<T> : CompanyICrud<T> { }
    public class CompanyRepository<T> : ICompanyRepository<T> where T:IEntity
    {
        ICompanyDbContext<T> _ctx;
        public CompanyRepository(ICompanyDbContext<T> ctx)
        {
            _ctx = ctx;
        }
        public T GetById(int id)
        {
            return _ctx.GetById(id);
        }

        public T save(T entity)
        {
            return _ctx.save(entity);
        }
    }
}
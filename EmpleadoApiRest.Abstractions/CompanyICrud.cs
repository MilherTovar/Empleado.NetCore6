namespace EmpleadoApiRest.Abstractions
{
    public interface CompanyICrud<T>
    {
        T save(T entity);
        T GetById(int id);
    }
}
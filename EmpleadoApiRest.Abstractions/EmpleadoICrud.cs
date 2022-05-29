using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoApiRest.Abstractions
{
    public interface EmpleadoICrud<T>
    {
        T save(T entity);
        IList<T> GetAll();
        T GetById(int id);
        void Delete(int id);

        T Update(T entity);
    }
}

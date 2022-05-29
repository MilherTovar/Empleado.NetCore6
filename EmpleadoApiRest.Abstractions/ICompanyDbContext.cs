using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoApiRest.Abstractions
{
    public interface ICompanyDbContext<T>:CompanyICrud<T>
    {
    }
}

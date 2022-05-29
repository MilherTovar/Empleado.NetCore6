using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoApiRest.Entities
{
    public class Company : Entity
    {
        public string CompanyName { get; set; }
        public string LegalRepresentCompany { get; set; }
        public bool Activo { get; set; } = true;
    }
}

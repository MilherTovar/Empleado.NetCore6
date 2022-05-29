using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoApiRest.Entities
{
    public class Empleado:Entity
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public double Identificacion { get; set; }
        public string email { get; set; }

        public bool Activo { get; set; } = true;
        [ForeignKey("Company")]
        public int idCompany { get; set; }

        [ForeignKey("idCompany")]
        public virtual Company Companys { get; set; }
    }
}

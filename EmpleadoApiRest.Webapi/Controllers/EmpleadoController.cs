using EmpleadoApiRest.Application;
using EmpleadoApiRest.Entities;
using EmpleadoApiRest.Webapi.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadoApiRest.Webapi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        IEmpleadoApplication<Empleado> _empleado;
        public EmpleadoController(IEmpleadoApplication<Empleado> empleado)
        {
            _empleado = empleado;
        }

        [HttpPost]
        public IActionResult save(EmpleadoDTO dto)
        {
            var e = new Empleado()
            {
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                email = dto.email,
                Identificacion = dto.Identificacion,
                idCompany = dto.idCompany
            };
            return Ok(_empleado.save(e));
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_empleado.GetAll());
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_empleado.GetById(id));
        }

        [HttpPut]
        [Route("Put")]
        public IActionResult PutEmpleado(EmpleadoDTO dto)
        {
            var e = new Empleado()
            {
                Id=dto.id,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                email = dto.email,
                Identificacion = dto.Identificacion,
                idCompany = dto.idCompany
            };
            return Ok(_empleado.Update(e));
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public IActionResult DeleteEmpleado(int id)
        {
            _empleado.Delete(id);
            return Ok("Eliminación exitosa");
        }
    }
}

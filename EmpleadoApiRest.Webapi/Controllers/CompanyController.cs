using EmpleadoApiRest.Application;
using EmpleadoApiRest.Entities;
using EmpleadoApiRest.Webapi.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadoApiRest.Webapi.Controllers
{
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        ICompanyApplication<Company> _company;
        public CompanyController(ICompanyApplication<Company> company)
        {
            _company = company;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_company.GetById(2));
        }

        [HttpPost]
        public IActionResult save(CompanyDTO dto)
        {
            var c = new Company()
            {
                CompanyName = dto.CompanyName,
                LegalRepresentCompany = dto.LegalRepresentCompany
            };
            return Ok(_company.save(c));
        }
    }
}

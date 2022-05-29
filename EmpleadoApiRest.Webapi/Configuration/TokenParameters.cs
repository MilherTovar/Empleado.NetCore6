using EmpleadoApiRest.Abstractions;

namespace EmpleadoApiRest.Webapi.Configuration
{
    public class TokenParameters:ITokenParameters
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Id { get; set; }
    }
}

namespace EmpleadoApiRest.Webapi.DTOs
{
    public class EmpleadoDTO
    {
        public int id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public double Identificacion { get; set; }
        public string email { get; set; }
        public int idCompany { get; set; }
    }
}

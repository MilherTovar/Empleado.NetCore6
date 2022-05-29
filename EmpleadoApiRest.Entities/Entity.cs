using EmpleadoApiRest.Abstractions;

namespace EmpleadoApiRest.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
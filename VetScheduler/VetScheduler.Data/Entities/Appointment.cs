using VetScheduler.Data.Interfaces;

namespace VetScheduler.Data.Entities
{
    public class Appointment : IEntityId<Guid>
    {
        public Appointment() { }
        public Guid Id { get; set; }
    }
}

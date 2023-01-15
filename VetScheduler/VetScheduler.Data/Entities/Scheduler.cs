using VetScheduler.Data.Interfaces;

namespace VetScheduler.Data.Entities
{
    public class Scheduler : IEntityId<Guid>
    {
        public Scheduler() { }
        public Guid Id { get; set; }

    }
}

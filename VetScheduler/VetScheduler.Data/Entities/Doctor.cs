using VetScheduler.Data.Interfaces;

namespace VetScheduler.Data.Entities
{
    public class Doctor : IEntityId<int>
    {
        public Doctor() { }
        public int Id { get; set; }
    }
}

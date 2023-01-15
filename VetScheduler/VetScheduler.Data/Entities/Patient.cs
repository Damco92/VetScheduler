using VetScheduler.Data.Interfaces;

namespace VetScheduler.Data.Entities
{
    public class Patient : IEntityId<int>
    {
        public Patient() { }
        public int Id { get; set; }
    }
}

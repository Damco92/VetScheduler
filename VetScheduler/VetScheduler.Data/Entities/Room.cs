using VetScheduler.Data.Interfaces;

namespace VetScheduler.Data.Entities
{
    public class Room : IEntityId<int>
    {
        public Room() { }
        public int Id { get; set; }
    }
}

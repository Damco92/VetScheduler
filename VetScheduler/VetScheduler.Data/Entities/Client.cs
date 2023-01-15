using VetScheduler.Data.Interfaces;

namespace VetScheduler.Data.Entities
{
    public class Client : IEntityId<int>
    {
        public Client() { }
        public int Id { get; set; }
    }
}
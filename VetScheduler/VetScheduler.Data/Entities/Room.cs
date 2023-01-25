using VetScheduler.VetScheduler.Shared;

namespace VetScheduler.Data.Entities
{
    public class Room : BaseEntity<int>
    {
        public Room(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return Name.ToString();
        }

        public Room UpdateName(string name)
        {
            Name = name;
            return this;
        }
    }
}

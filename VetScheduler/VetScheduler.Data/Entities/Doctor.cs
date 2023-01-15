namespace VetScheduler.Data.Entities
{
    public class Doctor : BaseEntity<int>
    {
        public Doctor(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}

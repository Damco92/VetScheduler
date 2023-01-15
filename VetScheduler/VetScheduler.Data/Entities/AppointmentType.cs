using VetScheduler.VetScheduler.Shared;

namespace VetScheduler.Data.Entities
{
    public class AppointmentType : BaseEntity<int>
    {
        public AppointmentType(int id, string name, string code, int duration)
        {
            Id = id;
            Name = name;
            Code = code;
            Duration = duration;
        }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public int Duration { get; private set; }
    }
}

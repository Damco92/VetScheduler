
namespace VetScheduler.Data.Entities
{
    public class Client : BaseEntity<int>
    {
        public Client(int id)
        {
            Id = id;
            Patients = new List<Patient>();
        }

        public Client(string fullName,
          string preferredName,
          string salutation,
          int preferredDoctorId,
          string emailAddress)
        {
            FullName = fullName;
            PreferredName = preferredName;
            Salutation = salutation;
            PreferredDoctorId = preferredDoctorId;
            EmailAddress = emailAddress;
        }

        public string FullName { get; private set; }
        public string PreferredName { get; private set; }
        public string Salutation { get; private set; }
        public string EmailAddress { get; private set; }
        public int PreferredDoctorId { get; private set; }
        public IList<Patient> Patients { get; private set; } = new List<Patient>();
        public override string ToString()
        {
            return FullName.ToString();
        }
    }
}
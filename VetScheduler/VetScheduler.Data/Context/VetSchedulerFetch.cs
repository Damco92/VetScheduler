using Microsoft.EntityFrameworkCore;
using VetScheduler.Data.Entities;

namespace VetScheduler.Data.Context
{
    public class VetSchedulerFetch : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
    }
}

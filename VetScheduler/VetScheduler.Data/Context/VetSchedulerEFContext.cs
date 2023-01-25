using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using VetScheduler.Data.Entities;

namespace VetScheduler.Data.Context
{
    public class VetSchedulerEFContext : DbContext
    {
        private readonly IMediator _mediator;

        public VetSchedulerEFContext(DbContextOptions<VetSchedulerEFContext> options, IMediator mediator)
        : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}

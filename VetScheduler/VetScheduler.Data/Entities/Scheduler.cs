using System;
using VerScheduler.Shared;

namespace VetScheduler.Data.Entities
{
    public class Scheduler : BaseEntity<Guid>
    {
        public Scheduler(Guid id, DateTimeOffsetRange dateRange, int clinicId)
        {
            Id = id;
            DateRange = dateRange;
            ClinicId = clinicId;
        }

        private Scheduler(Guid id, int clinicId)
        {
            Id = id;
            ClinicId = clinicId;
        }

        public int ClinicId { get; private set; }
        private readonly List<Appointment> _appointments = new List<Appointment>();
        public IEnumerable<Appointment> Appointments => _appointments.AsReadOnly();

        public DateTimeOffsetRange DateRange { get; private set; }

        public void AddNewAppointment(Appointment appointment)
        {
            //TODO: Add guard clauses if appointment is null, appointment id is default GUID and if is a duplicate appointment

            _appointments.Add(appointment);

            MarkConflictingAppointments();
        }

        public void DeleteAppointment(Appointment appointment)
        {
            //TODO: add guard clause if appointment is null


            var appointmentToDelete = _appointments
                                      .Where(a => a.Id == appointment.Id)
                                      .FirstOrDefault();

            if (appointmentToDelete != null)
            {
                _appointments.Remove(appointmentToDelete);
            }

            MarkConflictingAppointments();
        }




        private void MarkConflictingAppointments()
        {
            foreach (var appointment in _appointments)
            {
                // same patient cannot have two appointments at same time
                var potentiallyConflictingAppointments = _appointments
                    .Where(a => a.PatientId == appointment.PatientId &&
                    a.TimeRange.Overlaps(appointment.TimeRange) &&
                    a != appointment)
                    .ToList();

                // TODO: Add a rule to mark overlapping appointments in same room as conflicting
                // TODO: Add a rule to mark same doctor with overlapping appointments as conflicting

                potentiallyConflictingAppointments.ForEach(a => a.IsPotentiallyConflicting = true);

                appointment.IsPotentiallyConflicting = potentiallyConflictingAppointments.Any();
            }
        }

        /// <summary>
        /// Call any time this schedule's appointments are updated directly
        /// </summary>
        public void AppointmentUpdatedHandler()
        {
            // TODO: Add ScheduleHandler calls to UpdateDoctor, UpdateRoom to complete additional rules described in MarkConflictingAppointments
            MarkConflictingAppointments();
        }

    }
}

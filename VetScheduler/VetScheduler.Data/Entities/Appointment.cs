using System;
using VerScheduler.Shared;

namespace VetScheduler.Data.Entities
{
    public class Appointment : BaseEntity<Guid>
    {
        public Appointment(Guid id,
            int appointmentTypeId,
            Guid scheduleId,
            int clientId,
            int doctorId,
            int patientId,
            int roomId,
            DateTimeOffsetRange timeRange,
            string title,
            DateTime? dateTimeConfirmed = null)
        {
            Id = id;
            AppointmentTypeId = appointmentTypeId;
            ScheduleId = scheduleId;
            ClientId = clientId;
            DoctorId = doctorId;
            PatientId = patientId;
            RoomId = roomId;
            TimeRange = timeRange;
            Title = title;
            DateTimeConfirmed = dateTimeConfirmed;
        }

        public Guid ScheduleId { get; private set; }
        public int ClientId { get; private set; }
        public int PatientId { get; private set; }
        public int RoomId { get; private set; }
        public int DoctorId { get; private set; }
        public int AppointmentTypeId { get; private set; }

        public DateTimeOffsetRange TimeRange { get; private set; }
        public string Title { get; private set; }
        public DateTimeOffset? DateTimeConfirmed { get; set; }
        public bool IsPotentiallyConflicting { get; set; }

        public void UpdateRoom(int newRoomId)
        {
            //TODO: add guard clause if newroomid is negative or zero

            if (newRoomId == RoomId) return;

            RoomId = newRoomId;
        }

        public void UpdateDoctor(int newDoctorId)
        {
            //Add guard clause if newDoctorId is negative or zero

            if (newDoctorId == DoctorId) return;

            DoctorId = newDoctorId;
        }

        public void UpdateStartTime(DateTimeOffset newStartTime,
          Action scheduleHandler)
        {
            if (newStartTime == TimeRange.Start) return;

            TimeRange = new DateTimeOffsetRange(newStartTime, TimeSpan.FromMinutes(TimeRange.DurationInMinutes()));

            scheduleHandler?.Invoke();
        }

        public void UpdateTitle(string newTitle)
        {
            if (newTitle == Title) return;

            Title = newTitle;
        }

        public void UpdateAppointmentType(AppointmentType appointmentType,
          Action scheduleHandler)
        {
            //TODO: add guard clause if appointment type is null


            if (AppointmentTypeId == appointmentType.Id) return;

            AppointmentTypeId = appointmentType.Id;
            TimeRange = TimeRange.NewEnd(TimeRange.Start.AddMinutes(appointmentType.Duration));

            scheduleHandler?.Invoke();
        }

        public void Confirm(DateTimeOffset dateConfirmed)
        {
            if (DateTimeConfirmed.HasValue) return; // no need to reconfirm

            DateTimeConfirmed = dateConfirmed;
        }
    }
}

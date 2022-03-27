using MCN.Core.Entities.Entities.appointment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.AppointmentRepositoryBLs.Dtos
{
  public  class AppointmentDto
    {
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public DateTime Date { get; set; }
        public TimeSlots SelectTimeSlot { get; set; }
        public int? AppointmentId { get; set; }
    }
}

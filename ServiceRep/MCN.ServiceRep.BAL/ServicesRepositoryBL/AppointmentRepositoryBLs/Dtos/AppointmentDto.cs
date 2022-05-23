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
        public string SelectTimeSlot { get; set; }
        public int? AppointmentId { get; set; }

        public int? SalonId { get; set; }
        public string DoctorName { get; set; }
        public string SalonName { get; set; }
        public string UserName { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string phone { get; set; }
    }
}

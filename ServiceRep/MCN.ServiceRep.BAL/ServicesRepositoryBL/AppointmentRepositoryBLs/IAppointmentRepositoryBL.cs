using MCN.Common.AttribParam;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.AppointmentRepositoryBLs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.AppointmentRepositoryBLs
{
   public interface IAppointmentRepositoryBL
    {
        SwallResponseWrapper searchDoctors(SearchDoctorFilterDto search);
        SwallResponseWrapper RegisterAppointment(AppointmentDto appointmentDto);
        SwallResponseWrapper RegisterTimeSlot(AppointmentDto appointmentDto);
        SwallResponseWrapper GetDoctor(int id);
        SwallResponseWrapper GetSpecialities();
        SwallResponseWrapper SaveSpecialities(SpecialitiesDto specialitiesDto);
        SwallResponseWrapper GetAppointments(int doctorid);
        SwallResponseWrapper GetPatientAppointments(int patientId);
    }
}

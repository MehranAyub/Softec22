using MCN.Common.AttribParam;
using MCN.Core.Entities.Entities;
using MCN.Core.Entities.Entities.appointment;
using MCN.ServiceRep.BAL.ContextModel;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.AppointmentRepositoryBLs.Dtos;
using System;
using System.Linq;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.AppointmentRepositoryBLs
{
   public class AppointmentRepositoryBL : BaseRepository, IAppointmentRepositoryBL
    {
        private readonly SwallResponseWrapper _swallResponseWrapper;
        private readonly SwallText _swallText;
        public static int DEFAULT_USERID = 1;

        public AppointmentRepositoryBL(RepositoryContext repository) : base(repository)
        {
            _swallResponseWrapper = new SwallResponseWrapper();
            _swallText = new SwallText();
            repositoryContext = repository;
        }

        public SwallResponseWrapper searchDoctors(SearchDoctorFilterDto search)
        {  
            var data = (from DS in repositoryContext.DoctorSpecialist.Where(x => search.SpecialistId.Contains((int)x.SpecialistId))
                                join u in repositoryContext.Users.Where(x => (x.Description.Contains(search.Keyword) || x.FirstName.Contains(search.Keyword) || x.LastName.Contains(search.Keyword) && x.UserLoginTypeId== UserEntityType.Doctor)) on DS.DoctorId equals u.ID
                                join s in repositoryContext.Specialist on DS.SpecialistId equals s.ID
                                select new
                                {
                                    id=u.ID,
                                    FirstName=u.FirstName,
                                    LastName=u.LastName,
                                    Description=u.Description,
                                    Email=u.Email,
                                    Phone=u.Phone,
                                    Specialisty= new {Name=s.Name}
                                }).ToList();

          
                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = data
                };
            } 

        public SwallResponseWrapper RegisterAppointment(AppointmentDto appointmentDto)
        {
            try
            {
                var app = new Appointment();
                app.DoctorId = appointmentDto.DoctorId;
                app.PatientId = appointmentDto.PatientId;              
                repositoryContext.Appointment.Add(app);
                repositoryContext.SaveChanges();

                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = app
                };
            }
            catch(Exception ex)
            {
                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 400,
                    Data = null
                };
            }
        }

        public SwallResponseWrapper RegisterTimeSlot(AppointmentDto appointmentDto)
        {
            try
            {
                var app = new TimeSlot();
                app.DoctorId = appointmentDto.DoctorId;
                app.TimeSlots = appointmentDto.SelectTimeSlot;
                app.Date = appointmentDto.Date;
                app.AppointmentId = appointmentDto.AppointmentId;

                repositoryContext.TimeSlot.Add(app);
                repositoryContext.SaveChanges();

                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = app
                };
            }
            catch (Exception ex)
            {
                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 400,
                    Data = null
                };
            }
        }

        public SwallResponseWrapper GetDoctor(int id)
        {
            try
            {
                var record = repositoryContext.Users.FirstOrDefault(x => x.ID == id);

                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = record
                };
            }
            catch (Exception ex)
            {
                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 404,
                    Data = null
                };
            }
        }

        public SwallResponseWrapper GetSpecialities()
        {
            try
            {
                var record = repositoryContext.Specialist.ToList();

                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = record
                };
            }
            catch (Exception ex)
            {
                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 404,
                    Data = null
                };
            }
        }


        public SwallResponseWrapper SaveSpecialities(SpecialitiesDto specialitiesDto)
        {
            try
            {
                foreach(var item in specialitiesDto.DoctorSpecialitiesDtos)
                {
                    var obj = new DoctorSpecialist();
                    obj.DoctorId = item.DoctorId;
                    obj.SpecialistId = item.SpecialistId;
                    repositoryContext.DoctorSpecialist.Add(obj);
                } 
                repositoryContext.SaveChanges();

                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 404,
                    Data = null
                };
            }
        }


        public SwallResponseWrapper GetAppointments(int doctorid)
        {
            try
            {
                var record = (from app in repositoryContext.Appointment
                              join user in repositoryContext.Users on app.PatientId equals user.ID
                              where app.DoctorId == doctorid && user.UserLoginTypeId == UserEntityType.Patient
                              select user).ToList();

                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = record
                };
            }
            catch (Exception ex)
            {
                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 404,
                    Data = null
                };
            }
        }
    }
}

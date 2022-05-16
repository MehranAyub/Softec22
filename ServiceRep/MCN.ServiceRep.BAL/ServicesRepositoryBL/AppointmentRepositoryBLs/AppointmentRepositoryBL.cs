using MCN.Common.AttribParam;
using MCN.Core.Entities.Entities;
using MCN.Core.Entities.Entities.appointment;
using MCN.ServiceRep.BAL.ContextModel;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.AppointmentRepositoryBLs.Dtos;
using System;
using System.Linq;
using System.Text;
using static MCN.Common.AttribParam.SwallTextData;
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
            var doctorSpecialities = repositoryContext.DoctorSpecialist.AsQueryable();
            var users = repositoryContext.Users.Where(x=>x.UserLoginTypeId == UserEntityType.Doctor).AsQueryable();
            if (search.SpecialistId.Length > 0)
            {
                 doctorSpecialities = doctorSpecialities.Where(x => search.SpecialistId.Contains((int)x.SpecialistId));

            }

            if (search.Keyword.Length > 0)
            {
                users= users.Where(x => (x.Description.Contains(search.Keyword) || x.FirstName.Contains(search.Keyword) || x.LastName.Contains(search.Keyword)));
            }
            var data = (from DS in doctorSpecialities
                        join u in users on DS.DoctorId equals u.ID
                        join s in repositoryContext.Specialist on DS.SpecialistId equals s.ID
                                select new
                                {
                                    id=u.ID,
                                    FirstName=u.FirstName,
                                    LastName=u.LastName,
                                    Description=u.Description,
                                    Address=u.Address,
                                    Latitude = u.Latitude,
                                    Longitude = u.Longitude,
                                    Email =u.Email,
                                    Phone=u.Phone,
                                    Specialities= (from DSS in doctorSpecialities
                                                  join ss in repositoryContext.Specialist on DSS.SpecialistId equals ss.ID where DSS.DoctorId == u.ID select ss).ToList()
                                }).Distinct();

          
                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = data.ToList()
                };
            } 

        public SwallResponseWrapper RegisterAppointment(AppointmentDto appointmentDto)
        {
            try
            {
                string date = appointmentDto.Date.ToString("dd-MM-yyyy");

                var record = repositoryContext.AvailSlots.FirstOrDefault(x => x.Date == date && x.BarberID == appointmentDto.DoctorId);
                var slot = new AvailSlots();
                if (record != null)
                {
                    if (appointmentDto.SelectTimeSlot == "8:00 am")
                    {
                        record.S1 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "9:00 am")
                    {
                        record.S2 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "10:00 am")
                    {
                        record.S3 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "11:00 am")
                    {
                        record.S4 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "12:00 pm")
                    {
                        record.S5 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "01:00 pm")
                    {
                        record.S6 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "02:00 pm")
                    {
                        record.S7 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "03:00 pm")
                    {
                        record.S8 = 1;
                    }
                    repositoryContext.Update(record);

                }
                else
                {
                    slot.BarberID = (int)appointmentDto.DoctorId;
                    slot.Date = date;
                    if (appointmentDto.SelectTimeSlot == "8:00 am")
                    {
                        slot.S1 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "9:00 am")
                    {
                        slot.S2 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "10:00 am")
                    {
                        slot.S3 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "11:00 am")
                    {
                        slot.S4 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "12:00 pm")
                    {
                        slot.S5 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "01:00 pm")
                    {
                        slot.S6 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "02:00 pm")
                    {
                        slot.S7 = 1;
                    }
                    else if (appointmentDto.SelectTimeSlot == "03:00 pm")
                    {
                        slot.S8 = 1;
                    }
                    repositoryContext.AvailSlots.Add(slot);
                }
                
                var app = new Appointment();
                app.DoctorId = appointmentDto.DoctorId;
                var rec = repositoryContext.Users.FirstOrDefault(x => x.ID == appointmentDto.DoctorId);
                app.DoctorName = rec.FirstName + ' ' + rec.LastName;
                app.Location = rec.Address;
                app.phone = rec.Phone;
                app.date = date;
                app.status = 1;
                rec = repositoryContext.Users.FirstOrDefault(x => x.ID == appointmentDto.PatientId);
                app.PatientId = appointmentDto.PatientId;
                app.UserName= rec.FirstName + ' ' + rec.LastName;
                //app.DoctorNname = appointmentDto.DoctorName;
                //app.UserName = appointmentDto.UserName;
                app.Time = appointmentDto.SelectTimeSlot;
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
               // app.TimeSlots = appointmentDto.SelectTimeSlot;
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
        public SwallResponseWrapper FindSlots(AppointmentDto appointmentDto)
        {
            try
            {
                var apps = new AvailSlots();
               string date=appointmentDto.Date.ToString("dd-MM-yyyy");
               
                var record = repositoryContext.AvailSlots.FirstOrDefault(x => x.Date == date&&x.BarberID==appointmentDto.DoctorId);
                if (record!=null)
                {
                   
                    if (record.S1!=1)
                    {
                        apps.S1 = 0;
                    }
                    if (record.S2 != 1)
                    {
                        apps.S2 = 0;
                    }
                    if (record.S3 != 1)
                    {
                        apps.S3 = 0;
                    }
                    if (record.S4 != 1)
                    {
                        apps.S4 = 0;
                    }
                    if (record.S5 != 1)
                    {
                        apps.S5 = 0;
                    }
                    if (record.S6 != 1)
                    {
                        apps.S6 = 0;
                    }
                    if (record.S7 != 1)
                    {
                        apps.S7 = 0;
                    }
                    if (record.S8 != 1)
                    {
                        apps.S8 = 0;
                    }
                }
                else
                {
                    apps.S1 = 0;
                    apps.S2 = 0;
                    apps.S3 = 0;
                    apps.S4 = 0;
                    apps.S5 = 0;
                    apps.S6 = 0;
                    apps.S7 = 0;
                    apps.S8 = 0;
                }
               
                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = apps
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

        public SwallResponseWrapper CancelAppointment(int id)
        {
            try
            {
                var app = repositoryContext.Appointment.FirstOrDefault(x=>x.ID==id);
                var record = repositoryContext.AvailSlots.FirstOrDefault(x => x.BarberID == app.DoctorId && x.Date==app.date);

                if (app.Time == "8:00 am")
                {
                    record.S1 = null;
                }
                else if (app.Time == "9:00 am")
                {
                    record.S2 = null;
                }
                else if (app.Time == "10:00 am")
                {
                    record.S3 = null;
                }
                else if (app.Time == "11:00 am")
                {
                    record.S4 = null;
                }
                else if (app.Time == "12:00 pm")
                {
                    record.S5 = null;
                }
                else if (app.Time == "01:00 pm")
                {
                    record.S6 = null;
                }
                else if (app.Time == "02:00 pm")
                {
                    record.S7 = null;
                }
                else if (app.Time == "03:00 pm")
                {
                    record.S8 = null;
                }
                repositoryContext.Update(record);

                repositoryContext.Appointment.Remove(app);
                repositoryContext.SaveChanges();
                return new SwallResponseWrapper()
                {
                    SwallText = new Commons().Delete,
                    StatusCode = 200,
                    Data = "Done"
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

        public SwallResponseWrapper UpdateUser(AppointmentDto dto)
        {

            var record = repositoryContext.Users.FirstOrDefault(x => x.ID == dto.DoctorId);
            record.FirstName = dto.firstName;
            record.LastName = dto.lastName;
            record.Phone = dto.phone;
            record.UpdatedOn = DateTime.Now;

            repositoryContext.Update(record);

            repositoryContext.SaveChanges();


            return new SwallResponseWrapper()
            {
                SwallText = LoginUser.UserCreatedScuccessfully,
                StatusCode = 200,
                Data = record
            };
        }

        public SwallResponseWrapper GetAppointments(int doctorid)
        {
            try
            {
                var record = repositoryContext.Appointment.Where(x => x.DoctorId == doctorid).ToList();

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


        public SwallResponseWrapper GetPatientAppointments(int patientId)
        {
            try
            {
                var record = repositoryContext.Appointment.Where(x => x.PatientId == patientId).ToList();
              
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

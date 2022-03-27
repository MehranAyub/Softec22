using MCN.Common.AttribParam;
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
                                join u in repositoryContext.Users.Where(x => (x.Description.Contains(search.Keyword) || x.FirstName.Contains(search.Keyword) || x.LastName.Contains(search.Keyword) && x.UserLoginTypeId==2)) on DS.DoctorId equals u.ID
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

    }
}

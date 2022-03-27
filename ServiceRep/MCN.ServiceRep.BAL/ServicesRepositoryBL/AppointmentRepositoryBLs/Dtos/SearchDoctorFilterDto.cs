using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.AppointmentRepositoryBLs.Dtos
{
   public class SearchDoctorFilterDto
    {
        public string Keyword { get; set; }
        public int[] SpecialistId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}

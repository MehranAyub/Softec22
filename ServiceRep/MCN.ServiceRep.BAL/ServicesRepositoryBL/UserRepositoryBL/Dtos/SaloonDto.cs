using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL.Dtos
{
   public class SalonDto
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public int RegisterBy { get; set; }
        public string Introduction { get; set; }

        public string About { get; set; }
    }
}

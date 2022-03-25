using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals.Dtos
{
 public   class LocationResultImage
    {
        public int ID { get; set; }
        public string Path { get; set; }
        public int Order { get; set; }
        public int LocationResultID { get; set; }
    }
}

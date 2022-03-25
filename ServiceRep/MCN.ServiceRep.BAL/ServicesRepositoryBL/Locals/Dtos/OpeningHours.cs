using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals.Dtos
{
   public class OpeningHour
    {
        public int ID { get; set; }
        public string Day { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int LocationResultID { get; set; }
    }
}

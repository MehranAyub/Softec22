using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals.Dtos
{
   public class Offer
    {
        public int ID { get; set; }
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public string ExpireTime { get; set; }
        public string Path { get; set; }
        public string Image { get; set; }

    }
}

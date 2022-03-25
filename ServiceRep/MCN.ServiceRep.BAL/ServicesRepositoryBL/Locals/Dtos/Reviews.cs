using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals.Dtos
{
   public class Reviews
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string PinLocation { get; set; }
        public string ReviewDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool FollowInd { get; set; }
        public int LocationResultID { get; set; }

    }
}

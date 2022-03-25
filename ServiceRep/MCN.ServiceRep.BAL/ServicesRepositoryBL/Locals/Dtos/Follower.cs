using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals.Dtos
{
  public  class Follower
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int LocationResultID { get; set; }
        public string Image { get; set; }
    }
}

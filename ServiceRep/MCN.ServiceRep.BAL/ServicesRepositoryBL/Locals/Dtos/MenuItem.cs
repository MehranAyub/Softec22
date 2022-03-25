using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals.Dtos
{
   public class MenuItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Path { get; set; }
    }
}

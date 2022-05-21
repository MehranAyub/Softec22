using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL.Dtos
{
  public  class FileDto
    {

        public int DocumentId { get; set; }

        public int UserId { get; set; }
        public string Name { get; set; }
     
        public string FileType { get; set; }
    
        public byte[] DataFiles { get; set; }
        public DateTime CreatedOn { get; set; }



    }
}

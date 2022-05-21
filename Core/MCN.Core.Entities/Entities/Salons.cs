using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MCN.Core.Entities.Entities
{
    [Table("Salon")]
    public class Salon
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }
        
        [MaxLength]
        public string SalonLogo { get; set; }
        public int RegisterBy { get; set; }

        [ForeignKey(nameof(RegisterBy))]
        public User Users { get; set; }


        [MaxLength]
        public string Introduction { get; set; }

        [MaxLength]
        public string About { get; set; }
       
    }
}

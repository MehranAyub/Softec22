using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MCN.Core.Entities.Entities.appointment
{
  public  class AvailSlots
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        public int BarberID { get; set; }

        [ForeignKey(nameof(BarberID))]
        public User Users { get; set; }
        public string? Date { get; set; }
        
        public int? S1 { get; set; }
        public int? S2 { get; set; }
        public int? S3 { get; set; }
        public int? S4 { get; set; }
        public int? S5 { get; set; }
        public int? S6 { get; set; }
        public int? S7 { get; set; }
        public int? S8 { get; set; }

    }
}

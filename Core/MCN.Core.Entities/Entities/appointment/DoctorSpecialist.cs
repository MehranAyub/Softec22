using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MCN.Core.Entities.Entities.appointment
{
   public class DoctorSpecialist
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public int?BarberId { get; set; }
        public int? SpecialistId { get; set; }

        [ForeignKey(nameof(BarberId))]
        public User Users { get; set; }
        [ForeignKey(nameof(SpecialistId))]
        public Specialist Specialist { get; set; }
    }
}

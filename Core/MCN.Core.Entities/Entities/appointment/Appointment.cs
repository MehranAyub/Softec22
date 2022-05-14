using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MCN.Core.Entities.Entities.appointment
{
   public class Appointment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public string? Time { get; set; }
        public string? DoctorName { get; set; }
        public string? UserName { get; set; }
        public int status { get; set; }
        public string? phone { get; set; }
        public string? date { get; set; }
        public string? Location { get; set; }
    }
}

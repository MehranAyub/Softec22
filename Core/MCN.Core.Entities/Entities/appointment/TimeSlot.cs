using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MCN.Core.Entities.Entities.appointment
{
  public  class TimeSlot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSlots TimeSlots { get; set; }
        public int? AppointmentId { get; set; }
        [ForeignKey(nameof(AppointmentId))]
        public Appointment Appointment { get; set; } 
    }

    public enum TimeSlots
    {
        Slot1=1,
        Slot2=2,
        Slot3=3,
        Slot4=4,
        Slot5=5,
        Slot6=6,
        Slot7=7,
        Slot8=8,
        Slot9=9,
        Slot10=10,
    }
}

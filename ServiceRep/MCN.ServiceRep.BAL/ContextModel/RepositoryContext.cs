using System;
using MCN.Core.Entities.Entities;
using MCN.Core.Entities.Entities.appointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata; 

namespace MCN.ServiceRep.BAL.ContextModel
{
   
    public class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<UserAuthtoken> UserAuthtoken { get; set; }
        public virtual DbSet<UserMultiFactor> UserMultiFactors { get; set; }
        public virtual DbSet<UserLoginType> UserLoginType { get; set; }
        public virtual DbSet<Specialist> Specialist { get; set; }
        public virtual DbSet<DoctorSpecialist> DoctorSpecialist { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<TimeSlot> TimeSlot { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=softecDb;Integrated Security=true;");
            }
        }
      
 
    }

}

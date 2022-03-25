using System;
using MCN.Core.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata; 

namespace MCN.ServiceRep.BAL.ContextModel
{
    [Keyless]
    public class GetUserAddressByDistance
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Title { get; set; }
        public double Distance { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

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
        public virtual DbSet<UserAuthtoken> UserAuthtoken { get; set; }
        public virtual DbSet<UserMultiFactor> UserMultiFactors { get; set; }
        public virtual DbSet<UserLoginType> UserLoginType { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=CYBERSPACE;Initial Catalog=softecDb;Integrated Security=true;");
            }
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    //Composite Primary Key for UserInterests
        //    builder.Entity<UserInterest>().HasKey(table => new { table.UserId, table.InterestId });
        //}

        //// Distance Calculator function
        //[DbFunction(nameof(DistanceKM))]
        //public static bool DistanceKM(double lat, double lng)
        //{
        //    throw new Exception(); 
        //}
    }

}

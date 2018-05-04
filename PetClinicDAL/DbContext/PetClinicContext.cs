using System.Data.Entity;
using System.Xml.Xsl;
using PetClinicDAL.Entities;

namespace PetClinicDAL.DbContext
{
    internal class PetClinicContext : System.Data.Entity.DbContext
    {
        public PetClinicContext() : base("PetClinicConnectionString")
        {
        }

        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Enroll> Enrolls { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Reception> Receptions { get; set; }
        public DbSet<Scheduler> Schedulers { get; set; } 
    }
}

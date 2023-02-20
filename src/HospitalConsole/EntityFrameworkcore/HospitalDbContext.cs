using HospitalConsole.Domain;
using System.Data.Entity;


namespace Hospital.EntityFrameworkcore
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> patienttable { get; set; }
        public DbSet<Appuser> Appusertable { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appuser>()
                .HasIndex(p => p.Username)
                .IsUnique();
        }

        public HospitalDbContext() : base("Server=localhost;Database=Hospital;Trusted_Connection=True ;")
        {
        }
    }
}

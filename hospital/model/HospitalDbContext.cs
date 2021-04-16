using Microsoft.EntityFrameworkCore;

namespace hospital.model
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                .HasIndex(e => e.svnr)
                .IsUnique();
            builder.Entity<Caretakers>()
                .HasOne(c => c.superior)
                .WithOne();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Caretakers> Caretakers { get; set; }
        public DbSet<Physicians> Physicians { get; set; }
    }
}
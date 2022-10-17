using Microsoft.EntityFrameworkCore;

namespace hospital.model
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Caretakers> Caretakers { get; set; }
        public DbSet<Physicians> Physicians { get; set; }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Wards> Wards { get; set; }
        public DbSet<CTHasWards> CareWards { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                .HasIndex(e => e.Svnr)
                .IsUnique();
            builder.Entity<Facilities>()
                .HasIndex(f => f.Name)
                .IsUnique();
            builder.Entity<Facilities>()
                .HasIndex(f => f.PhoneNr)
                .IsUnique();
            builder.Entity<Caretakers>()
                .HasOne(c => c.Superior)
                .WithOne();
            builder.Entity<Wards>()
                .HasOne<Physicians>()
                .WithMany();
            builder.Entity<Wards>()
                .HasKey(w => new {w.HospitalId, w.Name});
            builder.Entity<CTHasWards>()
                .HasKey(c => new {c.CaretakerId, c.WardName, c.Hours});
        }
    }
}
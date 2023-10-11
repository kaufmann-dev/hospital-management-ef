using Microsoft.EntityFrameworkCore;

namespace hospital.model {
    public class HospitalDbContext : DbContext{

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) {
            
        }
        public DbSet<AEmployee> Employees { get; set; }

        public DbSet<Physician> Physicans { get; set; }

        public DbSet<Caretaker> Caretakers { get; set; }

        public DbSet<Facility> HospitalFacilities { get; set; }

        public DbSet<Ward> Wards { get; set; }

        public DbSet<Occupation> Occupations { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<AEmployee>()
                .HasIndex(e => e.Svnr)
                .IsUnique();

            builder.Entity<Caretaker>()
                .HasOne(c => c.Superior)
                .WithMany()
                .HasForeignKey(c => c.SuperiorId);
            
            builder.Entity<Facility>()
                .HasIndex(h => h.Name)
                .IsUnique();

            builder.Entity<Facility>()
                .HasIndex(h => h.PhoneNr)
                .IsUnique();

            builder.Entity<Ward>()
                .HasOne(w => w.Manager)
                .WithOne()
                .HasForeignKey<Ward>(w => w.ManagerId);

            builder.Entity<Ward>()
                .HasOne(w => w.Facility)
                .WithMany()
                .HasForeignKey(w => w.FacilityId);

            builder.Entity<Occupation>()
                .HasKey(o => new {o.EmployeeId, o.WardId});

            builder.Entity<Occupation>()
                .HasOne(o => o.Employee)
                .WithMany()
                .HasForeignKey(o => o.EmployeeId);

            builder.Entity<Occupation>()
                .HasOne(o => o.Ward)
                .WithMany()
                .HasForeignKey(o => o.WardId);
        }
        
    }
}
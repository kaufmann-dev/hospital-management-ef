using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace hospital.model
{
    public class HospitalDbContextFactory : IDesignTimeDbContextFactory<HospitalDbContext>
    {
        public HospitalDbContext CreateDbContext(string[] args)
        {
            var properties = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).UseMySql(
                properties["ConnectionStrings:DefaultConnection"], ServerVersion.FromString("8.0.22"), null);
            return new HospitalDbContext(optionsBuilder.Options);
        }
    }
}
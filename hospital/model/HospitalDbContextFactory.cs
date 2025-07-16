using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace hospital.model {
    public class HospitalContextFactory : IDesignTimeDbContextFactory<HospitalDbContext> {
        
        public HospitalDbContext CreateDbContext(string[] args) {
            var properties = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();

            optionsBuilder
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseMySql(
                    properties["ConnectionStrings:DefaultConnection"],
                    new MySqlServerVersion(new Version(8,0,23)),
                    null
                );

            return new HospitalDbContext(optionsBuilder.Options);
        }
    }
}
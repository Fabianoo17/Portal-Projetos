using Core.Business.Entities.Identity;
using Core.Business.Helpers;
using Core.Infra.Data.Mappings.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Core.Infra.Data.Context
{
    public class CPTDB001DbContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = new LoggerFactory().AddConsole();

        public DbSet<DadosAD> DadosAD { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Identity
            modelBuilder.ApplyConfiguration(new DadosADMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = ConfigurationBuilderHelper.GetConfiguration();
            var connection = configuration.GetConnectionString("CPTDB001ConnectionString");

            optionsBuilder
                .UseSqlServer(connection)
                .UseLoggerFactory(MyLoggerFactory);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
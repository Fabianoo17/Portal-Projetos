using Core.Business.Entities.Identity;
using Core.Business.Entities.Projetos;
using Core.Business.Helpers;
using Core.Infra.Data.Mappings.Identity;
using Core.Infra.Data.Mappings.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Core.Infra.Data.Context
{
    public class DefaultDbContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = new LoggerFactory().AddConsole();

        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<UsuarioAcesso> UsuariosAcesso { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet <MarcosEntrega> MarcosEntrega { get; set; }
        public DbSet <MarcosEntregasAtivos> MarcosEntregaAtivos { get; set; }
        public DbSet <MarcosEntregaRelacionado> MarcosEntregaRelacionado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Identity
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new UsuarioAcessoMap());
            modelBuilder.ApplyConfiguration(new UsuarioPerfilMap());
            modelBuilder.ApplyConfiguration(new UsuarioVinculadoMap());

            // Projeto
            modelBuilder.ApplyConfiguration(new TipoProjetoMap());
            modelBuilder.ApplyConfiguration(new StatusProjetoMap());
            modelBuilder.ApplyConfiguration(new ProjetoMap());
            modelBuilder.ApplyConfiguration(new ObjetivoMap());
            modelBuilder.ApplyConfiguration(new CustoMap());
            modelBuilder.ApplyConfiguration(new JustificativaMap());
            modelBuilder.ApplyConfiguration(new RestricaoMap());
            modelBuilder.ApplyConfiguration(new RiscoMap());
            modelBuilder.ApplyConfiguration(new BeneficioMap());
            modelBuilder.ApplyConfiguration(new PremissaMap());
            modelBuilder.ApplyConfiguration(new MarcosEntregaMap());
            modelBuilder.ApplyConfiguration(new ArquivoMap());
            modelBuilder.ApplyConfiguration(new ParteInteressadaMap());
            modelBuilder.ApplyConfiguration(new ApoioMap());
            modelBuilder.ApplyConfiguration(new UnidadesMap());
            modelBuilder.ApplyConfiguration(new DashboardMap());
            modelBuilder.ApplyConfiguration(new PrioridadeMap());
            modelBuilder.ApplyConfiguration(new ComplexidadeMap());
            modelBuilder.ApplyConfiguration(new EscopoMap());
            modelBuilder.ApplyConfiguration(new NaoEscopoMap());
            modelBuilder.ApplyConfiguration(new RequisitoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ResponsavelMap());
            modelBuilder.ApplyConfiguration(new TipoMarcosEntregaMap());
            modelBuilder.ApplyConfiguration(new AtividadesEntregaMap());
            modelBuilder.ApplyConfiguration(new StatusAtividadeMarcoEntregaMap());
            modelBuilder.ApplyConfiguration(new MarcosEntregaRelacionadoMap());

            // In Dev
            // Config String Type
            var properties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string))
                .Select(p => modelBuilder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name));

            foreach (var property in properties)
            {
                property
                    .HasMaxLength(100)
                    .IsUnicode(false);
            }

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = ConfigurationBuilderHelper.GetConfiguration();
            var connection = configuration.GetConnectionString("DefaultConnectionString");

            optionsBuilder
                .UseSqlServer(connection)
                .UseLoggerFactory(MyLoggerFactory);

            base.OnConfiguring(optionsBuilder);
        }
    }    
}
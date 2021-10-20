using Core.Business.Extensions;
using Core.Business.Helpers;
using Core.Business.Interfaces;
using Core.Business.Interfaces.Repositories;
using Core.Business.Interfaces.Repositories.Identity;
using Core.Business.Interfaces.Services;
using Core.Business.Notificacoes;
using Core.Business.Services;
using Core.Infra.Data.Context;
using Core.Infra.Data.Repositories;
using Core.Infra.Data.Repositories.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infra.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddSingleton<ServerHelper>();

            // Services - App
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<IParametroService, ParametroService>();

            // Infra - Data
            services.AddScoped<DefaultDbContext>();
            services.AddScoped<CPTDB001DbContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioAcessoRepository, UsuarioAcessoRepository>();
            services.AddScoped<IDadosADRepository, DadosADRepository>();

            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IMarcosEntregaRepository, MarcosEntregaRepository>();
            services.AddScoped<ITipoProjetoRepository, TipoProjetoRepository>();
            services.AddScoped<IStatusProjetoRepository, StatusProjetoRepository>();
            services.AddScoped<IUnidadesRepository, UnidadesRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<IComplexidadeRepository, ComplexidadeRepository>();
            services.AddScoped<IPrioridadeRepository, PrioridadeRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IResponsavelRepository, ResponsavelRepository>();
            services.AddScoped<ITipoMarcosEntregasRepository, TipoMarcosEntregasRepository>();
            services.AddScoped<IStatusAtividadeMarcoEntregaRepository, StatusAtividadeMarcoEntregaRepository>();


            // Infra - Filter

            return services;
        }
    }
}

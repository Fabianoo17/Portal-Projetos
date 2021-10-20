using Core.Business.Interfaces;
using Core.Business.Interfaces.Repositories;
using Core.Business.Security;
using Core.Business.ViewModels.Identity;
using Core.Infra.IoC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Web.Security
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AdministradorOuGerenteOuVinculadoAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IUser _user;

        public AdministradorOuGerenteOuVinculadoAttribute()
        {
            var serviceProvider = NativeInjectorServiceProvider.ServiceProvider();
            _projetoRepository = serviceProvider.GetService<IProjetoRepository>();
            _user = serviceProvider.GetService<IUser>();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User != null && context.HttpContext.User.Identity.IsAuthenticated)
            {
                int projetoId = Convert.ToInt32(context.RouteData.Values["CO_PROJETO"]);

                var isAdministrator = CustomAuthorizationHelper.ValidarClaimsUsuario(context.HttpContext.User, new[] { EPerfil.Administrador });

                if (!isAdministrator)
                {
                    if (!_projetoRepository.PossuiAcessoAoProjeto(projetoId, _user.Matricula))
                        context.Result = new ForbidResult();
                }
            }
        }
    }
}

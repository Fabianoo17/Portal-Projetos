using Core.Business.Security;
using Core.Business.ViewModels.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Web.Security
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AdministradorAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User != null && context.HttpContext.User.Identity.IsAuthenticated)
            {
                var isAdministrator = CustomAuthorizationHelper.ValidarClaimsUsuario(context.HttpContext.User, new[] { EPerfil.Administrador });

                if (!isAdministrator)
                    context.Result = new ForbidResult();
            }
        }
    }
}

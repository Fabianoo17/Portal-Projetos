using Core.Business.Security;
using Core.Business.ViewModels.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.Web.Security
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }

        public CustomAuthorizeAttribute(EPerfil[] perfisNecessarios) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { perfisNecessarios };
        }
    }

    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;
        private readonly EPerfil[] _perfisNecessarios;
        private bool isClaim;

        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
            isClaim = true;
        }

        public RequisitoClaimFilter(EPerfil[] perfisNecessarios)
        {
            _perfisNecessarios = perfisNecessarios;
            isClaim = false;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (isClaim)
            {
                if (!CustomAuthorizationHelper.ValidarClaimsUsuario(context.HttpContext.User, _claim))
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }

            if (!CustomAuthorizationHelper.ValidarClaimsUsuario(context.HttpContext.User, _perfisNecessarios))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}

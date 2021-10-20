using System.Security.Claims;
using Core.Business.Helpers;
using Core.Business.Interfaces;
using Core.Business.Security;
using Core.Business.ViewModels.Identity;
using Core.Infra.IoC;
using Core.Web.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Web.Extensions
{
    public static class RazorPageExtension
    {
        public static IUser GetUserCustom(this RazorPageBase razorPageBase)
        {
            var serviceProvider = NativeInjectorServiceProvider.ServiceProvider();
            var user = serviceProvider.GetService<IUser>();
            return user;
        }

        public static bool CustomAuthorize(this RazorPageBase razorPage, string claimName, string claimValue)
        {
            return CustomAuthorizationHelper.ValidarClaimsUsuario(GetClaimsPrincipal(), new Claim(claimName, claimValue));
        }

        public static bool CustomAuthorize(this RazorPageBase razorPage, EPerfil[] perfisNecessarios)
        {
            return CustomAuthorizationHelper.ValidarClaimsUsuario(GetClaimsPrincipal(), perfisNecessarios);
        }

        public static bool IsEnvironmentDev(this RazorPageBase razorPage)
        {
            var serviceProvider = NativeInjectorServiceProvider.ServiceProvider();
            var server = serviceProvider.GetService<ServerHelper>();
            return server.IsEnvironmentDev();
        }

        private static ClaimsPrincipal GetClaimsPrincipal()
        {
            var serviceProvider = NativeInjectorServiceProvider.ServiceProvider();
            var context = serviceProvider.GetService<IHttpContextAccessor>();
            return context.HttpContext.User;
        }
    }
}
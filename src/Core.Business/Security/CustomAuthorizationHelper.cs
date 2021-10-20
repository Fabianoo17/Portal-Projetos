using System;
using System.Linq;
using System.Security.Claims;
using Core.Business.ViewModels.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Core.Business.Security
{
    public static class CustomAuthorizationHelper
    {
        public static bool ValidarClaimsUsuario(ClaimsPrincipal claimsPrincipal, Claim claim)
        {
            return claimsPrincipal.Identity.IsAuthenticated &&
                   claimsPrincipal.Claims.Any(c => c.Type == claim.Type && c.Value.Contains(claim.Value));
        }

        public static bool ValidarClaimsUsuario(ClaimsPrincipal claimsPrincipal, EPerfil[] perfisNecessarios)
        {
            if (!claimsPrincipal.Identity.IsAuthenticated)
                return false;

            bool containsPerfil = false;

            var perfisClam = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "Perfis");
            if (perfisClam != null)
            {
                string[] perfis = perfisClam.Value.Split(',');
                var perfisEnum = perfis?.Select(x => (EPerfil)Convert.ToInt32(x)).ToList();
                foreach (var p in perfisNecessarios)
                {
                    if (perfisEnum.Contains(p))
                    {
                        containsPerfil = true;
                        break;
                    }
                }
            }
            return containsPerfil;
        }
    }
}
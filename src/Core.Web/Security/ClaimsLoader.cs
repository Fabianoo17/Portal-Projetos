using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Business.Extensions;
using Core.Business.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.Caching;

namespace Core.Web.Security
{
    public class ClaimsLoader : IClaimsTransformation
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMemoryCache _cache;

        public ClaimsLoader(IUsuarioService usuarioService,
                            IMemoryCache cache)
        {
            _usuarioService = usuarioService;
            _cache = cache;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal.Identity.IsAuthenticated)
            {
                string cacheKey, matricula;
                cacheKey = matricula = ObterMatricula((ClaimsIdentity)principal.Identity);
                if (_cache.TryGetValue(cacheKey, out List<Claim> claims))
                {
                    ((ClaimsIdentity)principal.Identity).AddClaims(claims);
                }
                else
                {
                    claims = await _usuarioService.ObterClaims(matricula);
                    ((ClaimsIdentity)principal.Identity).AddClaims(claims);
                    _cache.Set(cacheKey, claims, TimeSpan.FromMinutes(3));
                }
            }
            return principal;
        }

        private string ObterMatricula(ClaimsIdentity claimsIdentity)
        {
            if (claimsIdentity != null && claimsIdentity.IsAuthenticated)
            {
                string matriculaCompleta = claimsIdentity.Name;
                string expressao = @"\w+\\";
                Regex rgx = new Regex(expressao);
                return rgx.Replace(matriculaCompleta, "").ToUpper();
            }
            //return "C099721";
            return Environment.UserName.ToUpper();
        }
    }
}
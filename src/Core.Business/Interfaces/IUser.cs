using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Core.Business.Interfaces
{
    public interface IUser
    {
        string Nome { get; }
        string Matricula { get; }
        string UnidadeNome { get; }
        string UnidadeCodigo { get; }
        bool IsAuthenticated();
        bool IsInRole(string role);
        ClaimsPrincipal GetClaimsPrincipal();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
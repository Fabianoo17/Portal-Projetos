using Core.Business.Entities;
using Core.Business.Interfaces;
using Core.Business.Notificacoes;
using Core.Business.Security;
using Core.Business.ViewModels.Identity;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;
        protected IUser UserCustom { get; private set; }

        protected BaseService(INotificador notificador,
                              IUser user)
        {
            _notificador = notificador;
            UserCustom = user;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid)
                return true;

            Notificar(validator);

            return false;
        }

        protected bool CustomAuthorize(string claimName, string claimValue)
        {
            return CustomAuthorizationHelper.ValidarClaimsUsuario(UserCustom.GetClaimsPrincipal(), new Claim(claimName, claimValue));
        }

        protected bool CustomAuthorize(EPerfil[] perfisNecessarios)
        {
            return CustomAuthorizationHelper.ValidarClaimsUsuario(UserCustom.GetClaimsPrincipal(), perfisNecessarios);
        }
    }
}
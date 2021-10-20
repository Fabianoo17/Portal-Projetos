using Core.Business.Entities.Identity;
using FluentValidation;

namespace Core.Business.EntitiesValidations
{
    public class UsuarioAcessoValidation : AbstractValidator<UsuarioAcesso>
    {
        public UsuarioAcessoValidation()
        {
            RuleFor(x => x.MATRICULA)
                .NotEmpty();

            RuleFor(x => x.UsuariosPerfis)
                .NotEmpty();
        }
    }
}
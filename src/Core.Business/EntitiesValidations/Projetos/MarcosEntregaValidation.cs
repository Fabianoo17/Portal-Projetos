using Core.Business.Entities.Projetos;
using FluentValidation;

namespace Core.Business.EntitiesValidations.Projetos
{
    public class MarcosEntregaValidation : AbstractValidator<MarcosEntrega>
    {
        public MarcosEntregaValidation()
        {
            RuleFor(x => x.CO_PROJETO)
                .NotEmpty();

            RuleFor(x => x.DESCRICAO)
                .NotEmpty();

            RuleFor(x => x.DT_CADASTRO)
                .NotEmpty();
        }
    }
}
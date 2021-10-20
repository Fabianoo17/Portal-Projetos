using Core.Business.Entities.Projetos;
using FluentValidation;

namespace Core.Business.EntitiesValidations.Projetos
{
    public class ArquivoValidation : AbstractValidator<Arquivo>
    {
        public ArquivoValidation()
        {
            RuleFor(x => x.CO_PROJETO)
                .NotEmpty();

            RuleFor(x => x.NOME)
               .NotEmpty();

            RuleFor(x => x.ENDERECO)
                .NotEmpty();

            RuleFor(x => x.DT_CADASTRO)
                .NotEmpty();
        }
    }
}
using Core.Business.Entities.Projetos;
using FluentValidation;

namespace Core.Business.EntitiesValidations.Projetos
{
    public class ProjetoValidation : AbstractValidator<Projeto>
    {
        public ProjetoValidation()
        {
            RuleFor(x => x.NOME).NotEmpty();

            //RuleFor(x => x.DT_FIM)
            //    .GreaterThan(x => x.DT_INICIO).WithMessage("A 'DATA FIM' deve ser maior que a 'DATA INÍCIO'.");

            //RuleFor(x => x.DT_CADASTRO)
            //    .NotEmpty();

            //RuleForEach(x => x.Objetivos)
            //    .SetValidator(new ObjetivoValidation());

            //RuleForEach(x => x.Custos)
            //    .SetValidator(new CustoValidation());

            //RuleForEach(x => x.Justificativas)
            //    .SetValidator(new JustificativaValidation());

            //RuleForEach(x => x.Restricoes)
            //    .SetValidator(new RestricaoValidation());

            //RuleForEach(x => x.Riscos)
            //    .SetValidator(new RiscoValidation());

            //RuleForEach(x => x.Beneficios)
            //    .SetValidator(new BeneficioValidation());

            //RuleForEach(x => x.Premissas)
            //    .SetValidator(new PremissaValidation());

            //RuleForEach(x => x.MarcosEntregas)
            //    .SetValidator(new MarcosEntregaValidation());

            //RuleForEach(x => x.Arquivos)
            //    .SetValidator(new ArquivoValidation());
        }
    }
}
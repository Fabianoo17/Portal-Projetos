using Core.Business.Helpers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> IsValidCPF<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => string.IsNullOrEmpty(x) || CpfCnpjHelper.IsCPF(x))
                .WithMessage("O CPF é inválido");
        }

        public static IRuleBuilderOptions<T, string> IsValidCNPJ<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => string.IsNullOrEmpty(x) || CpfCnpjHelper.IsCNPJ(x))
                .WithMessage("O CNPJ é inválido");
        }
    }
}

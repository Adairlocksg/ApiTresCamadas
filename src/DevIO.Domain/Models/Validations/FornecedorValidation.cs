using FluentValidation;
using static DevIO.Business.Models.Validations.Documents.ValidationDocs;

namespace DevIO.Business.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(p => p.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
            {
                RuleFor(p => p.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo Documento precisa ter {ComparsionValue} caracteres e foi fornecido {PropertyValue}");

                RuleFor(p => CpfValidacao.Validar(p.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido");
            });

            When(p => p.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(p => p.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                   .WithMessage("O campo Documento precisa ter {ComparsionValue} caracteres e foi fornecido {PropertyValue}");

                RuleFor(p => CnpjValidacao.Validar(p.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido");
            });
        }
    }
}

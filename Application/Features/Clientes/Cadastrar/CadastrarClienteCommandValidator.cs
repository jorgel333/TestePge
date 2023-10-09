using FluentValidation;

namespace Application.Features.Clientes.Cadastrar;

public class CadastrarClienteCommandValidator : AbstractValidator<CadastrarClienteCommand>
{
    public CadastrarClienteCommandValidator()
    {
        RuleFor(x => x.NomeCliente).NotEmpty()
            .MaximumLength(120);

        RuleFor(x => x.CpfCliente).NotEmpty()
            .Matches(@"^\d{11}$").WithMessage("O CPF deve conter 11 digitos númericos");
    }
}

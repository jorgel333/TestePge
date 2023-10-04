using FluentValidation;

namespace Application.Features.Clientes.Cadastrar;

public class CadastrarClienteCommandValidator : AbstractValidator<CadastrarClienteCommand>
{
    public CadastrarClienteCommandValidator()
    {
        RuleFor(x => x.Nome).NotEmpty()
            .MaximumLength(120);

        RuleFor(x => x.Cpf).NotEmpty()
            .Matches(@"^\d{11}$").WithMessage("O CPF deve conter 11 digitos númericos");
    }
}

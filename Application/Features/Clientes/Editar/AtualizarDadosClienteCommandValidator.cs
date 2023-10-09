using FluentValidation;

namespace Application.Features.Clientes.Editar;

public class AtualizarDadosClienteCommandValidator : AbstractValidator<AtualizarDadosClienteCommand>
{
    public AtualizarDadosClienteCommandValidator()
    {
        RuleFor(x => x.Nome).NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Cpf).NotEmpty()
            .Matches(@"^\d{11}$").WithMessage("O CPF deve conter 11 digitos númericos");
    }
}

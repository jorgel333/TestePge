using FluentValidation;

namespace Application.Features.Advogados.Cadastrar;

public class CadastrarAdvogadoCommandValidator : AbstractValidator<CadastrarAdvogadoCommand>
{
	public CadastrarAdvogadoCommandValidator()
	{
		RuleFor(x => x.Nome).NotEmpty()
			.MaximumLength(120);

		RuleFor(x => x.Cpf).NotEmpty()
			.Matches(@"^\d{11}$").WithMessage("O CPF deve conter 11 digitos númericos");

		RuleFor(x => x.Oab).NotEmpty()
			.Matches(@"^\d+$").MaximumLength(6);

    }
}

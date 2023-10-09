using FluentValidation;

namespace Application.Features.Processos.Cadastrar;

public class CriarProcessoJudicialCommandValidator : AbstractValidator<CriarProcessoJudicialCommand>
{
    public CriarProcessoJudicialCommandValidator()
    {
        RuleFor(p => p.Tema).NotEmpty().MaximumLength(100);

        RuleFor(p => p.ValorCausa).GreaterThan(0);

        RuleFor(p => p.Descricao).NotEmpty().MaximumLength(400);
    }
}

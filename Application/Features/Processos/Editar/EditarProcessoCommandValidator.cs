using FluentValidation;

namespace Application.Features.Processos.Editar;

public class EditarProcessoCommandValidator :AbstractValidator<EditarProcessoCommand>
{
    public EditarProcessoCommandValidator()
    {
        RuleFor(p => p.Tema).NotEmpty().MaximumLength(100);

        RuleFor(p => p.ValorCausa).GreaterThan(0);

        RuleFor(p => p.Descricao).NotEmpty().MaximumLength(400);
    }
}

using FluentValidation;

namespace Application.Features.Documentos.AnexarDocumentos;

public class AnexarDocumentosCommandValidator : AbstractValidator<AnexarDocumentosCommand>
{
	public AnexarDocumentosCommandValidator()
	{
        RuleFor(x => x.Documentos).NotNull();
    }
}

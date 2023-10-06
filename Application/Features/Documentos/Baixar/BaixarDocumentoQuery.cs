using FluentResults;
using MediatR;

namespace Application.Features.Documentos.Baixar;

public record BaixarDocumentoQuery(int Id) : IRequest<Result<BaixarDocumentoQueryResponse>>;

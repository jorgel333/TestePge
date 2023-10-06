using FluentResults;
using MediatR;

namespace Application.Features.Documentos.DesanexarDocumentos;

public record DesanexarDocumentoCommand(int Id) : IRequest<Result>;

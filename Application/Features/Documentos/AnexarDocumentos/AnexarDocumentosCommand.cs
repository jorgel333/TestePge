using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Documentos.AnexarDocumentos;

public record AnexarDocumentosCommand(int Id, IEnumerable<IFormFile> Documentos) : IRequest<Result>;

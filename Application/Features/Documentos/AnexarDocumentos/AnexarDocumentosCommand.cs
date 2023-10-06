using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Documentos.AnexarDocumentos;

public record AnexarDocumentosCommand(int NumeroProcesso, IEnumerable<IFormFile> Documentos) : IRequest<Result>;

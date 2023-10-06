using Microsoft.AspNetCore.Http;

namespace Application.Features.Documentos.AnexarDocumentos;

public record AnexarDocumentosCommandRequest(IEnumerable<IFormFile> Documentos);

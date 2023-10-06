using Application.Erros;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Documentos.Baixar;

public class BaixarDocumentoQueryHandler : IRequestHandler<BaixarDocumentoQuery, Result<BaixarDocumentoQueryResponse>>
{
    private readonly IDocumentoRepository _documentoRepository;

    public BaixarDocumentoQueryHandler(IDocumentoRepository documentoRepository)
    {
        _documentoRepository = documentoRepository;
    }

    public async Task<Result<BaixarDocumentoQueryResponse>> Handle(BaixarDocumentoQuery request, CancellationToken cancellationToken)
    {
        var documento = await _documentoRepository.BuscarDocumento(request.Id, cancellationToken);

        if (documento is null)
            return Result.Fail(new ApplicationNotFoundError("Documento Não encontrado"));

        return Result.Ok(new BaixarDocumentoQueryResponse(documento!));
    }
}

using Domain.Interfaces.Repositories;
using Application.Erros;
using FluentResults;
using MediatR;
using Application.Dtos;

namespace Application.Features.Processos.BuscarDetalhes;

public class BuscarDetalhesProcessoQueryHandler : IRequestHandler<BuscarDetalhesProcessoQuery, Result<BuscarDetalhesProcessoQueryResponse>>
{
    private readonly IProcessoJudicialRepository _processoRepository;

    public BuscarDetalhesProcessoQueryHandler(IProcessoJudicialRepository processoRepository)
    {
        _processoRepository = processoRepository;
    }

    public async Task<Result<BuscarDetalhesProcessoQueryResponse>> Handle(BuscarDetalhesProcessoQuery request, CancellationToken cancellationToken)
    {
        var processo = await _processoRepository.BuscarProcessoDetalhes(request.NumeroProcesso, cancellationToken);
        
        if (processo is null)
            return Result.Fail(new ApplicationNotFoundError("Processo não encontrado"));
        
        var response = new BuscarDetalhesProcessoQueryResponse(processo.NumeroProcesso,
            processo.Tema!,
            processo.ValorCausa.ToString("F2"),
            processo.Descricao,
            processo.AdvogadoResponsavel!.Nome!,
            processo.Parte!.Nome!,
            processo.Documentos!.Select(x => new DocumentoDto (x.Id, x.Nome)) ?? Enumerable.Empty<DocumentoDto>());
        
        return Result.Ok(response);
    }
}

using Domain.Interfaces.Repositories;
using Application.Erros;
using FluentResults;
using MediatR;
using Domain.Entities;

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
            processo.ValorCausa,
            processo.AdvogadoResponsavel!.Nome!,
            processo.Parte!.Nome!,
            processo.Documentos!.Select(x => x.Nome!) ?? Enumerable.Empty<string>());
        
        return Result.Ok(response);
    }
}

using Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace Application.Features.Processos.BuscarTodos;

public class BuscarTodosProcessosQueryHandler : IRequestHandler<BuscarTodosProcessosQuery, Result<IEnumerable<BuscarTodosProcessosQueryResponse>>>
{
    private readonly IProcessoJudicialRepository _processoRepository;

    public BuscarTodosProcessosQueryHandler(IProcessoJudicialRepository processoRepository)
    {
        _processoRepository = processoRepository;
    }

    public async Task<Result<IEnumerable<BuscarTodosProcessosQueryResponse>>> Handle(BuscarTodosProcessosQuery request, CancellationToken cancellationToken)
    {
        var processos = await _processoRepository.BuscarTodosProcessos(cancellationToken);

        var processosResponse = processos.Select(p => new BuscarTodosProcessosQueryResponse(p.NumeroProcesso,
            p.Tema!, p.Descricao.Length > 30 ? p.Descricao.Substring(0, 30) : p.Descricao)).OrderByDescending(p => p.NumeroProcesso);

        return Result.Ok(processosResponse ?? Enumerable.Empty<BuscarTodosProcessosQueryResponse>());
    }
}

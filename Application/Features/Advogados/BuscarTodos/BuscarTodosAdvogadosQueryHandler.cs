using Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace Application.Features.Advogados.BuscarTodos;

public class BuscarTodosAdvogadosQueryHandler : IRequestHandler<BuscarTodosAdvogadosQuery, Result<IEnumerable<BuscarTodosAdvogadosQueryResponse>>>
{
    public readonly IAdvogadoRepository _advogadoRepository;

    public BuscarTodosAdvogadosQueryHandler(IAdvogadoRepository advogadoRepository)
    {
        _advogadoRepository = advogadoRepository;
    }

    public async Task<Result<IEnumerable<BuscarTodosAdvogadosQueryResponse>>> Handle(BuscarTodosAdvogadosQuery request, CancellationToken cancellationToken)
    {
        var advogados = await _advogadoRepository.BuscarTodos(cancellationToken);

        var response = advogados.Select(x => new BuscarTodosAdvogadosQueryResponse(x.Id, x.Nome!));

        return Result.Ok(response ?? Enumerable.Empty<BuscarTodosAdvogadosQueryResponse>());
    }
}

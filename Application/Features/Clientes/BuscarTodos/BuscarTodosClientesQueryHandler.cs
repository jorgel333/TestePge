using Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace Application.Features.Clientes.BuscarTodos;

public class BuscarTodosClientesQueryHandler : IRequestHandler<BuscarTodosClientesQuery, Result<IEnumerable<BuscarTodosClientesQueryRersponse>>>
{
    private readonly IClienteRepository _clienteRepository;

    public BuscarTodosClientesQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Result<IEnumerable<BuscarTodosClientesQueryRersponse>>> Handle(BuscarTodosClientesQuery request, CancellationToken cancellationToken)
    {
        var clientes = await _clienteRepository.BuscarTodos(cancellationToken);

        var response = clientes.Select(x => new BuscarTodosClientesQueryRersponse(x.Id, x.Nome!));

        return Result.Ok(response ?? Enumerable.Empty<BuscarTodosClientesQueryRersponse>());
    }
}

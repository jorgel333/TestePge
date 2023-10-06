using Application.Erros;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace Application.Features.Clientes.Buscar;

public class BuscarClienteQueryHandler : IRequestHandler<BuscarClienteQuery, Result<BuscarClienteQueryResponse>>
{
    private readonly IClienteRepository _clienteRepository;

    public BuscarClienteQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Result<BuscarClienteQueryResponse>> Handle(BuscarClienteQuery request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.BuscarDetalhes(request.Id, cancellationToken);

        if (cliente is null)
            return Result.Fail(new ApplicationNotFoundError("Cliente não encontrado"));

        var response = new BuscarClienteQueryResponse(
            cliente.Nome!,
            cliente.Cpf!,
            cliente.Processos ?? Enumerable.Empty<ProcessoJudicial>());

        return Result.Ok(response);
    }
}

using FluentResults;
using MediatR;

namespace Application.Features.Clientes.Buscar;

public record BuscarClienteQuery(int Id) : IRequest<Result<BuscarClienteQueryResponse>>;

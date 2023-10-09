using FluentResults;
using MediatR;

namespace Application.Features.Clientes.BuscarTodos;

public record BuscarTodosClientesQuery : IRequest<Result<IEnumerable<BuscarTodosClientesQueryRersponse>>>;

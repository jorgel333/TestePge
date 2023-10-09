using FluentResults;
using MediatR;

namespace Application.Features.Processos.BuscarTodos;

public record BuscarTodosProcessosQuery() : IRequest<Result<IEnumerable<BuscarTodosProcessosQueryResponse>>>;

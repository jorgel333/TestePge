using FluentResults;
using MediatR;

namespace Application.Features.Advogados.BuscarTodos;

public record BuscarTodosAdvogadosQuery : IRequest<Result<IEnumerable<BuscarTodosAdvogadosQueryResponse>>>;

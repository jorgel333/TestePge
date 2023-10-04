using FluentResults;
using MediatR;

namespace Application.Features.Advogados.Excluir;

public record ExcluirAdvogadoCommand(int Id) : IRequest<Result>;

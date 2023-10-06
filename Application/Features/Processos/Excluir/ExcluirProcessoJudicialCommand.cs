using FluentResults;
using MediatR;

namespace Application.Features.Processos.Excluir;

public record ExcluirProcessoJudicialCommand(int Id) : IRequest<Result>;
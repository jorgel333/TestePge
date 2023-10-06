using FluentResults;
using MediatR;

namespace Application.Features.Processos.Editar;

public record EditarProcessoCommand(int Id, string Tema, double ValorCausa) : IRequest<Result>;

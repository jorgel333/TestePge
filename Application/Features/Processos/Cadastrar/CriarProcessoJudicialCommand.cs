using FluentResults;
using MediatR;

namespace Application.Features.Processos.Cadastrar;

public record CriarProcessoJudicialCommand(string Tema, double ValorCausa, int ClienteId, int AdvogadoId) : IRequest<Result>
{
}

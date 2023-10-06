using FluentResults;
using MediatR;

namespace Application.Features.Processos.Cadastrar;

public record CriarProcessoJudicialCommand(int NumeroProcesso, string Tema, double ValorCausa, int ClienteId, int AdvogadoId) : IRequest<Result>
{
}

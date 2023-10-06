using FluentResults;
using MediatR;

namespace Application.Features.Processos.BuscarDetalhes;

public record BuscarDetalhesProcessoQuery(int NumeroProcesso) : IRequest<Result<BuscarDetalhesProcessoQueryResponse>>;

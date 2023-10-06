using FluentResults;
using MediatR;

namespace Application.Features.Advogados.Buscar;

public record BuscarAdvogadoQuery (int Id) : IRequest<Result<BuscarAdvogadoQueryResponse>>;

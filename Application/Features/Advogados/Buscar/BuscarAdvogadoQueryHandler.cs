using Application.Dtos;
using Application.Erros;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace Application.Features.Advogados.Buscar;

public class BuscarAdvogadoQueryHandler : IRequestHandler<BuscarAdvogadoQuery, Result<BuscarAdvogadoQueryResponse>>
{
    private readonly IAdvogadoRepository _advogadoRepository;

    public BuscarAdvogadoQueryHandler(IAdvogadoRepository advogadoRepository)
    {
        _advogadoRepository = advogadoRepository;
    }

    public async Task<Result<BuscarAdvogadoQueryResponse>> Handle(BuscarAdvogadoQuery request, CancellationToken cancellationToken)
    {
        var advogado = await _advogadoRepository.BuscarDetalhes(request.Id, cancellationToken);

        if (advogado is null)
            return Result.Fail(new ApplicationNotFoundError("Advogado não encontrado"));

        var response = new BuscarAdvogadoQueryResponse(advogado.Id, advogado.Nome!,
            advogado.Cpf!,
            advogado.Oab!,
            advogado.Processos!.Select(x => new ProcessoJudicialAdvogadoDto(x.NumeroProcesso, x.Tema!, x.ValorCausa, x.Parte!.Nome!)) ?? Enumerable.Empty<ProcessoJudicialAdvogadoDto>());

        return Result.Ok(response);
    }
}

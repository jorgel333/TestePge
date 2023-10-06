using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace Application.Features.Processos.Cadastrar;

public class CriarProcessoJudicialCommandHandler : IRequestHandler<CriarProcessoJudicialCommand, Result>
{
    private readonly IProcessoJudicialRepository _processoRepository;
    private readonly IUnityOfWork _unityOfWork;

    public CriarProcessoJudicialCommandHandler(IProcessoJudicialRepository processoRepository, IUnityOfWork unityOfWork)
    {
        _processoRepository = processoRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(CriarProcessoJudicialCommand request, CancellationToken cancellationToken)
    {
        var processo = new ProcessoJudicial(request.Tema, request.ValorCausa)
        {
            ClienteId = request.ClienteId,
            AdvogadoId = request.AdvogadoId
        };

        _processoRepository.Criar(processo);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}

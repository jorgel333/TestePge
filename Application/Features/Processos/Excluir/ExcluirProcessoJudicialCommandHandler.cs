using Domain.Interfaces.Repositories;
using Domain.Interfaces;
using FluentResults;
using MediatR;
using Application.Erros;

namespace Application.Features.Processos.Excluir;

public class ExcluirProcessoJudicialCommandHandler : IRequestHandler<ExcluirProcessoJudicialCommand, Result>
{
    private readonly IProcessoJudicialRepository _processoRepository;
    private readonly IUnityOfWork _unityOfWork;

    public ExcluirProcessoJudicialCommandHandler(IProcessoJudicialRepository processoRepository, IUnityOfWork unityOfWork)
    {
        _processoRepository = processoRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(ExcluirProcessoJudicialCommand request, CancellationToken cancellationToken)
    {
        var processo = await _processoRepository.BuscarPorId(request.Id, cancellationToken);

        if (processo is null)
            return Result.Fail(new ApplicationNotFoundError("Processo não encontrado"));

        _processoRepository.Excluir(processo);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok();
    }
}

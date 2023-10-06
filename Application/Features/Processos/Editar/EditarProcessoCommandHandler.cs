using Domain.Interfaces.Repositories;
using Domain.Interfaces;
using FluentResults;
using MediatR;
using Application.Erros;

namespace Application.Features.Processos.Editar;

public class EditarProcessoCommandHandler : IRequestHandler<EditarProcessoCommand, Result>
{
    private readonly IProcessoJudicialRepository _processoRepository;
    private readonly IUnityOfWork _unityOfWork;

    public EditarProcessoCommandHandler(IProcessoJudicialRepository processoRepository, IUnityOfWork unityOfWork)
    {
        _processoRepository = processoRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(EditarProcessoCommand request, CancellationToken cancellationToken)
    {
        var processo = await _processoRepository.BuscarProcesso(request.NumeroProcesso, cancellationToken);

        if (processo is null)
            return Result.Fail(new ApplicationNotFoundError("Processo não encontrado"));

        processo.AtualizarDados(request.Tema, request.ValorCausa);        
        _processoRepository.Atualizar(processo);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}

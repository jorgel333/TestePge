using Domain.Interfaces.Repositories;
using Domain.Interfaces;
using FluentResults;
using MediatR;
using Application.Erros;

namespace Application.Features.Advogados.Excluir;

public class ExcluirAdvogadoCommandHandler : IRequestHandler<ExcluirAdvogadoCommand, Result>
{
    private readonly IAdvogadoRepository _advogadoRepository;
    private readonly IUnityOfWork _unityOfWork;

    public ExcluirAdvogadoCommandHandler(IAdvogadoRepository advogadoRepository, IUnityOfWork unityOfWork)
    {
        _advogadoRepository = advogadoRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(ExcluirAdvogadoCommand request, CancellationToken cancellationToken)
    {
        var advogado = await _advogadoRepository.BuscarPorId(request.Id, cancellationToken);

        if (advogado is null)
            return Result.Fail(new ApplicationNotFoundError("Advogado não encontrado"));

        _advogadoRepository.Excluir(advogado);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok();
    }
}

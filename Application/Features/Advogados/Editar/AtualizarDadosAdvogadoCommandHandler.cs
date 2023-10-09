using Domain.Interfaces.Repositories;
using Domain.Interfaces;
using FluentResults;
using MediatR;
using Application.Erros;
using Domain.Entities;

namespace Application.Features.Advogados.Editar;

public class AtualizarDadosAdvogadoCommandHandler : IRequestHandler<AtualizarDadosAdvogadoCommand, Result>
{
    private readonly IAdvogadoRepository _advogadoRepository;
    private readonly IUnityOfWork _unityOfWork;

    public AtualizarDadosAdvogadoCommandHandler(IAdvogadoRepository advogadoRepository, IUnityOfWork unityOfWork)
    {
        _advogadoRepository = advogadoRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(AtualizarDadosAdvogadoCommand request, CancellationToken cancellationToken)
    {
        var advogado = await _advogadoRepository.BuscarPorId(request.Id, cancellationToken);

        if (advogado is null)
            return Result.Fail(new ApplicationNotFoundError("Advogado não encontrado"));

        var cpfUnico = await _advogadoRepository.CpfUnico(request.Cpf, cancellationToken);
        var oabUnico = await _advogadoRepository.OabUnico(request.Oab, cancellationToken);

        if (advogado.Cpf != request.Cpf)
            if (cpfUnico is false)
                return Result.Fail(new ApplicationError("Cpf já cadastrado"));

        if (advogado.Oab != request.Oab)
            if (oabUnico is false)
                return Result.Fail(new ApplicationError("OAB já foi cadastrada"));

        advogado.AtualizarDados(request.Nome, request.Cpf, request.Oab);
        _advogadoRepository.Atualizar(advogado);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}

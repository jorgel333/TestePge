using Application.Erros;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace Application.Features.Advogados.Cadastrar;

public class CadastrarAdvogadoCommandHandler : IRequestHandler<CadastrarAdvogadoCommand, Result<CadastrarAdvogadoCommandResponse>>
{
    private readonly IAdvogadoRepository _advogadoRepository;
    private readonly IUnityOfWork _unityOfWork;

    public CadastrarAdvogadoCommandHandler(IAdvogadoRepository advogadoRepository, IUnityOfWork unityOfWork)
    {
        _advogadoRepository = advogadoRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result<CadastrarAdvogadoCommandResponse>> Handle(CadastrarAdvogadoCommand request, CancellationToken cancellationToken)
    {
        var cpfUnico = await _advogadoRepository.CpfUnico(request.Cpf, cancellationToken);
        var oabUnico = await _advogadoRepository.OabUnico(request.Oab, cancellationToken);

        if (cpfUnico is false)
            return Result.Fail(new ApplicationError("Cpf já cadastrado"));
        
        if (oabUnico is false)
            return Result.Fail(new ApplicationError("OAB já foi cadastrada"));

        var advogado = new Advogado(request.Nome, request.Cpf, request.Oab);

        _advogadoRepository.Criar(advogado);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(new CadastrarAdvogadoCommandResponse(advogado.Id));
    }
}

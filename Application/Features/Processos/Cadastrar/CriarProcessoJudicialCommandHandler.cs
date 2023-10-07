using Application.Erros;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace Application.Features.Processos.Cadastrar;

public class CriarProcessoJudicialCommandHandler : IRequestHandler<CriarProcessoJudicialCommand, Result>
{
    private readonly IProcessoJudicialRepository _processoRepository;
    private readonly IAdvogadoRepository _advogadoRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IUnityOfWork _unityOfWork;

    public CriarProcessoJudicialCommandHandler(IProcessoJudicialRepository processoRepository, IUnityOfWork unityOfWork, IAdvogadoRepository advogadoRepository, IClienteRepository clienteRepository)
    {
        _processoRepository = processoRepository;
        _unityOfWork = unityOfWork;
        _advogadoRepository = advogadoRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task<Result> Handle(CriarProcessoJudicialCommand request, CancellationToken cancellationToken)
    {
        var clienteCadastrado = await _clienteRepository.ClienteCadastrado(request.ClienteId, cancellationToken);

        if (clienteCadastrado is false)
            return Result.Fail(new ApplicationNotFoundError("Cliente não cadastrado"));

        var advogadoCadastrado = await _advogadoRepository.AdvogadoCadastrado(request.AdvogadoId, cancellationToken);

        if (advogadoCadastrado is false)
            return Result.Fail(new ApplicationNotFoundError("Advogado não cadastrado"));

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

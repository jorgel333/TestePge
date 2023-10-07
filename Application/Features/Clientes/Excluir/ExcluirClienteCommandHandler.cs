using Domain.Interfaces.Repositories;
using Domain.Interfaces;
using FluentResults;
using MediatR;
using Application.Erros;

namespace Application.Features.Clientes.Excluir;

public class ExcluirClienteCommandHandler : IRequestHandler<ExcluirClienteCommand, Result>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IUnityOfWork _unityOfWork;

    public ExcluirClienteCommandHandler(IClienteRepository clienteRepository, IUnityOfWork unityOfWork)
    {
        _clienteRepository = clienteRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(ExcluirClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.BuscarPorId(request.Id, cancellationToken);

        if (cliente is null)
            return Result.Fail(new ApplicationNotFoundError("Cliente não encontrado"));

        _clienteRepository.Excluir(cliente);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}

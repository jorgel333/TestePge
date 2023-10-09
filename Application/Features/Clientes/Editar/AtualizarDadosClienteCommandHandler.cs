using Domain.Interfaces.Repositories;
using Domain.Interfaces;
using FluentResults;
using MediatR;
using Application.Erros;

namespace Application.Features.Clientes.Editar;

public class AtualizarDadosClienteCommandHandler : IRequestHandler<AtualizarDadosClienteCommand, Result>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IUnityOfWork _unityOfWork;

    public AtualizarDadosClienteCommandHandler(IClienteRepository clienteRepository, IUnityOfWork unityOfWork)
    {
        _clienteRepository = clienteRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(AtualizarDadosClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.BuscarPorId(request.Id, cancellationToken);

        if (cliente is null)
            return Result.Fail(new ApplicationNotFoundError("Advogado não encontrado"));
        
        var cpfUnico = await _clienteRepository.CpfUnico(request.Cpf, cancellationToken);

        if (cliente.Cpf != request.Cpf)
            if (cpfUnico is false)
                return Result.Fail(new ApplicationError("Cpf já cadastrado"));

        cliente.AtualizarDados(request.Nome, request.Cpf);
        _clienteRepository.Atualizar(cliente);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}

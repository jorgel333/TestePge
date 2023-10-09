using Application.Erros;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces;
using FluentResults;
using MediatR;

namespace Application.Features.Clientes.Cadastrar;

public class CadastrarClienteCommandHandler : IRequestHandler<CadastrarClienteCommand, Result<CadastrarClienteCommandResponse>>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IUnityOfWork _unityOfWork;
    public CadastrarClienteCommandHandler(IClienteRepository clienteRepository, IUnityOfWork unityOfWork)
    {
        _clienteRepository = clienteRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result<CadastrarClienteCommandResponse>> Handle(CadastrarClienteCommand request, CancellationToken cancellationToken)
    {
        var cpfUnico = await _clienteRepository.CpfUnico(request.CpfCliente, cancellationToken);

        if (cpfUnico is false)
            return Result.Fail(new ApplicationError("Cpf já cadastrado"));

        var cliente = new Cliente(request.NomeCliente, request.CpfCliente);

        _clienteRepository.Criar(cliente);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(new CadastrarClienteCommandResponse(cliente.Id));
    }
}

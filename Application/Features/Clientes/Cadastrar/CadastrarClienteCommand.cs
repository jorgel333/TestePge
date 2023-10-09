using FluentResults;
using MediatR;

namespace Application.Features.Clientes.Cadastrar;

public record CadastrarClienteCommand (string NomeCliente, string CpfCliente) : IRequest<Result<CadastrarClienteCommandResponse>>;

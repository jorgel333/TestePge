using FluentResults;
using MediatR;

namespace Application.Features.Clientes.Cadastrar;

public record CadastrarClienteCommand (string Nome, string Cpf) : IRequest<Result<CadastrarClienteCommandResponse>>;

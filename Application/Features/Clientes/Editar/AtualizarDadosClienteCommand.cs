using FluentResults;
using MediatR;

namespace Application.Features.Clientes.Editar;

public record AtualizarDadosClienteCommand(int Id, string Nome, string Cpf) : IRequest<Result>;

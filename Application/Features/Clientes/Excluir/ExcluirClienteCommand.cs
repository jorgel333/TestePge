using FluentResults;
using MediatR;

namespace Application.Features.Clientes.Excluir;

public record ExcluirClienteCommand(int Id) : IRequest<Result>;
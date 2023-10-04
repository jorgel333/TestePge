using FluentResults;
using MediatR;

namespace Application.Features.Advogados.Cadastrar;

public record CadastrarAdvogadoCommand(string Nome, string Cpf, string Oab) : IRequest<Result<CadastrarAdvogadoCommandResponse>>;

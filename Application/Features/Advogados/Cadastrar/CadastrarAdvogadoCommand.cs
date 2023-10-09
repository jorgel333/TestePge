using FluentResults;
using MediatR;

namespace Application.Features.Advogados.Cadastrar;

public record CadastrarAdvogadoCommand(string NomeAdvogado, string CpfAdvogado, string Oab) : IRequest<Result<CadastrarAdvogadoCommandResponse>>;

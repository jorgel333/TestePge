using FluentResults;
using MediatR;

namespace Application.Features.Advogados.Editar;

public record AtualizarDadosAdvogadoCommand (int Id, string Nome, string Cpf, string Oab) : IRequest<Result>;

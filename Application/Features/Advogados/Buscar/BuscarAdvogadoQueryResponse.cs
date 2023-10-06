using Domain.Entities;

namespace Application.Features.Advogados.Buscar;

public record BuscarAdvogadoQueryResponse (string Nome, string Cpf, string Oab, IEnumerable<ProcessoJudicial> Processos);
using Application.Dtos;
using Domain.Entities;

namespace Application.Features.Advogados.Buscar;

public record BuscarAdvogadoQueryResponse (int Id, string Nome, string Cpf, string Oab, IEnumerable<ProcessoJudicialDto> Processos);
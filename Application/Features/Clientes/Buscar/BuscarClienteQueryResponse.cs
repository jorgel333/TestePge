using Application.Dtos;

namespace Application.Features.Clientes.Buscar;

public record BuscarClienteQueryResponse(int Id, string Nome, string Cpf, IEnumerable<ProcessoJudicialClienteDto> Processos);
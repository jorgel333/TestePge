using Domain.Entities;

namespace Application.Features.Clientes.Buscar;

public record BuscarClienteQueryResponse(string Nome, string Cpf, IEnumerable<ProcessoJudicial> Processos);
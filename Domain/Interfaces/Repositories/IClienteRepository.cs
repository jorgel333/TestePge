using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IClienteRepository
{
    void Atualizar(Cliente cliente);
    void Criar(Cliente cliente);
    void Excluir(Cliente cliente);
    Task<Cliente?> BuscarPorId(int id, CancellationToken cancellationToken);
    Task<Cliente?> BuscarDetalhes(int id, CancellationToken cancellationToken);
    Task<bool> ClienteCadastrado(int id, CancellationToken cancellationToken);
    Task<bool> CpfUnico(string cpf, CancellationToken cancellatioToken);
}

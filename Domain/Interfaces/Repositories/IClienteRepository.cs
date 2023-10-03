using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IClienteRepository
{
    void Atualizar(Cliente cliente);
    void Criar(Cliente cliente);
    void Excluir(Cliente cliente);
    Task<Cliente?> BuscarPorId(int id, CancellationToken cancellationToken);
}

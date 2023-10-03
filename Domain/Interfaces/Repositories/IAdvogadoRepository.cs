using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IAdvogadoRepository
{
    void Atualizar(Advogado advogado);
    void Criar(Advogado advogado);
    void Excluir(Advogado advogado);
    Task<Advogado?> BuscarPorId(int id, CancellationToken cancellationToken);
}

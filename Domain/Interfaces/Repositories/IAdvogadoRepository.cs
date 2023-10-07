using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IAdvogadoRepository
{
    void Atualizar(Advogado advogado);
    void Criar(Advogado advogado);
    void Excluir(Advogado advogado);
    Task<Advogado?> BuscarPorId(int id, CancellationToken cancellationToken);
    Task<Advogado?> BuscarDetalhes(int id, CancellationToken cancellationToken);
    Task<bool> AdvogadoCadastrado(int id, CancellationToken cancellationToken);
    Task<bool> CpfUnico(string cpf, CancellationToken cancellatioToken);
    Task<bool> OabUnico(string oab, CancellationToken cancellatioToken);
}

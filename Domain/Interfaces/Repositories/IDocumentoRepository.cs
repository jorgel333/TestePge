using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IDocumentoRepository
{
    void Anexar(Documento documentos);
    void Desanexar(IEnumerable<Documento> documentos);

    Task<IEnumerable<Documento>> BuscarDocumentos(int id, CancellationToken cancellationToken);
    Task<Documento?> BuscarDocumento(int id, CancellationToken cancellationToken);

}


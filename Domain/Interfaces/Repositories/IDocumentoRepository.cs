using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IDocumentoRepository
{
    void Anexar(IEnumerable<Documento> documentos);
    void Desanexar(IEnumerable<Documento> documentos);
}


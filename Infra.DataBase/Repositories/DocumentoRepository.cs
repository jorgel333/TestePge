using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.DataBase.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataBase.Repositories;

public class DocumentoRepository : IDocumentoRepository
{
    private readonly AppDbContext _context;

    public DocumentoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Anexar(Documento documentos)
        => _context.Add(documentos);

    public void Desanexar(Documento documentos)
        => _context.Documentos.Remove(documentos);

    public async Task<IEnumerable<Documento>> BuscarDocumentos(int NumeroProcecsso, CancellationToken cancellationToken)
        => await _context.Documentos.Where(x => x.NumeroProcesso == NumeroProcecsso).ToListAsync(cancellationToken);

    public async Task<Documento?> BuscarDocumento(int id, CancellationToken cancellationToken)
        => await _context.Documentos.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

}

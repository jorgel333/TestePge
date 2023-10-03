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

    public void Anexar(IEnumerable<Documento> documentos)
    {
        throw new NotImplementedException();
    }

    public void Desanexar(IEnumerable<Documento> documentos)
    {
        throw new NotImplementedException();
    }
}

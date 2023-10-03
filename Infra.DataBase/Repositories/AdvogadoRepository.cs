using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.DataBase.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataBase.Repositories;

public class AdvogadoRepository : IAdvogadoRepository
{
    private readonly AppDbContext _context;

    public AdvogadoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Criar(Advogado advogado)
       => _context.Advogados.Add(advogado);

    public void Excluir(Advogado advogado)
        => _context.Remove(advogado);

    public void Atualizar(Advogado advogado)
        => _context.Update(advogado);

    public async Task<Advogado?> BuscarPorId(int id, CancellationToken cancellationToken)
        => await _context.Advogados.Include(x => x.Clientes!).ThenInclude(x => x.Cliente!.Nome)
        .Include(x => x.Processos!).ThenInclude(x => x.NumeroProcesso)
        .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

   
}

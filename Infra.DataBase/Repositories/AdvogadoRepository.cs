using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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
        => await _context.Advogados.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<Advogado?> BuscarDetalhes(int id, CancellationToken cancellationToken)
        => await _context.Advogados.Include(x => x.Processos!).SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<bool> CpfUnico(string cpf, CancellationToken cancellatioToken)
             => await _context.Advogados.AnyAsync(adm => adm.Cpf! == cpf, cancellatioToken) is false;

    public async Task<bool> OabUnico(string oab, CancellationToken cancellatioToken)
             => await _context.Advogados.AnyAsync(adm => adm.Oab! == oab, cancellatioToken) is false;

    
}

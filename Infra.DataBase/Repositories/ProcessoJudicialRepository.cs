using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.DataBase.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataBase.Repositories;

public class ProcessoJudicialRepository : IProcessoJudicialRepository
{
    private readonly AppDbContext _context;
    public ProcessoJudicialRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Criar(ProcessoJudicial processo)
        => _context.ProcessosJudiciais.Add(processo);

    public void Atualizar(ProcessoJudicial processo)
        => _context.ProcessosJudiciais.Update(processo);

    public void Excluir(ProcessoJudicial processo)
        => _context.Remove(processo);

    public async Task<ProcessoJudicial?> BuscarProcessoDetalhes(int numeroProcesso, CancellationToken cancellationToken)
        => await _context.ProcessosJudiciais.Include(x => x.Documentos!)
        .Include(x => x.AdvogadoResponsavel)
        .Include(x => x.Parte)
        .SingleOrDefaultAsync(x => x.NumeroProcesso == numeroProcesso, cancellationToken);
    public async Task<ProcessoJudicial?> BuscarProcesso(int numeroProceesso, CancellationToken cancellationToken)
        => await _context.ProcessosJudiciais.SingleOrDefaultAsync(x => x.NumeroProcesso == numeroProceesso, cancellationToken);

    public async Task<ProcessoJudicial?> BuscarPorNumeroDoProcesso(int numeroProcesso, CancellationToken cancellationToken)
        => await _context.ProcessosJudiciais
        .SingleOrDefaultAsync(x => x.NumeroProcesso == numeroProcesso, cancellationToken);

    public Task<IEnumerable<ProcessoJudicial>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

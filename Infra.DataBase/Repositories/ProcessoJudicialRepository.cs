﻿using Domain.Entities;
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

    public async Task<ProcessoJudicial?> BuscarDetalhes(int id, CancellationToken cancellationToken)
        => await _context.ProcessosJudiciais.Include(x => x.Documentos)
        .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<ProcessoJudicial?> BuscarPorNumeroDoProcesso(string numeroProcesso, CancellationToken cancellationToken)
        => await _context.ProcessosJudiciais
        .SingleOrDefaultAsync(x => x.NumeroProcesso == numeroProcesso, cancellationToken);

    public Task<IEnumerable<ProcessoJudicial>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
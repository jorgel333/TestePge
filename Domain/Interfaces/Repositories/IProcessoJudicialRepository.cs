﻿using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IProcessoJudicialRepository
{
    void Atualizar(ProcessoJudicial processo);
    void Criar(ProcessoJudicial processo);
    void Excluir(ProcessoJudicial processo);
    Task<IEnumerable<ProcessoJudicial>> GetAll(CancellationToken cancellationToken);
    Task<ProcessoJudicial?> BuscarPorId(int id, CancellationToken cancellationToken);
    Task<ProcessoJudicial?> BuscarPorNumeroDoProcesso(int numeroProcesso, CancellationToken cancellationToken);
    Task<ProcessoJudicial?> BuscarDetalhes(int id, CancellationToken cancellationToken);
}

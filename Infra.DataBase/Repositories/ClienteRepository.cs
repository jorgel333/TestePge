using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.DataBase.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataBase.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Criar(Cliente cliente)
        => _context.Clientes.Add(cliente);

    public void Excluir(Cliente cliente)
        => _context.Clientes.Remove(cliente);

    public void Atualizar(Cliente cliente)
        => _context.Clientes.Update(cliente);

    public async Task<Cliente?> BuscarPorId(int id, CancellationToken cancellationToken)
        => await _context.Clientes.Include(x => x.Advogados!).ThenInclude(x => x.Advogado!.Nome)
        .Include(x => x.Processos!).ThenInclude(x => x.NumeroProcesso)
        .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<bool> CpfUnico(string cpf, CancellationToken cancellatioToken)
           => await _context.Advogados.AnyAsync(adm => adm.Cpf! == cpf, cancellatioToken) is false;
}

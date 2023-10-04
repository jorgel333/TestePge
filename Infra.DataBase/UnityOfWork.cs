using Domain.Interfaces;
using Infra.DataBase.Context;

namespace Infra.DataBase;

public class UnityOfWork : IUnityOfWork
{
    private readonly AppDbContext _context;

    public UnityOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

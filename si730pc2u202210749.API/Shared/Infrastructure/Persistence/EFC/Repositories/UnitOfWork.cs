using si730pc2u202210749.API.Shared.Domain.Repositories;
using si730pc2u202210749.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace si730pc2u202210749.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context) => _context = context;

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}
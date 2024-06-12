using Microsoft.EntityFrameworkCore;
using si730pc2u202210749.API.Logistics.Domain.Model.Aggregates;
using si730pc2u202210749.API.Logistics.Domain.Repositories;
using si730pc2u202210749.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730pc2u202210749.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730pc2u202210749.API.Logistics.Infrastructure.Persistence.EFC.Repositories;

public class InventoryRepository(AppDbContext context) : BaseRepository<Inventory>(context), IInventoryRepository
{
    public async Task<Inventory?> FindByProductIdAndWarehouseIdAsync(int productId, int warehouseId)
    {
        return await context.Inventories.FirstOrDefaultAsync(i => i.ProductId.ProductId == productId && i.WarehouseId.WarehouseId == warehouseId);
    }
        
}
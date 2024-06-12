using si730pc2u202210749.API.Logistics.Domain.Model.Aggregates;
using si730pc2u202210749.API.Logistics.Domain.Model.Queries;
using si730pc2u202210749.API.Logistics.Domain.Repositories;
using si730pc2u202210749.API.Logistics.Domain.Services;

namespace si730pc2u202210749.API.Logistics.Application.Internal.QueryServices;

public class InventoryQueryService(IInventoryRepository inventoryRepository) : IInventoryQueryService
{
    public async Task<IEnumerable<Inventory>> Handle(GetAllInventoriesQuery query)
    {
        return await inventoryRepository.ListAsync();
    }
    
    public async Task<Inventory?> Handle(GetInventoryByIdQuery query)
    {
        return await inventoryRepository.FindByIdAsync(query.InventoryId);
    }
    
    public async Task<Inventory?> Handle(GetInventoryByProductIdAndWarehouseId query)
    {
        return await inventoryRepository.FindByProductIdAndWarehouseIdAsync(query.ProductId, query.WarehouseId);
    }
}
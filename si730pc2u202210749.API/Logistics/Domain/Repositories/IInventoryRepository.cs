using si730pc2u202210749.API.Logistics.Domain.Model.Aggregates;
using si730pc2u202210749.API.Shared.Domain.Repositories;

namespace si730pc2u202210749.API.Logistics.Domain.Repositories;

public interface IInventoryRepository : IBaseRepository<Inventory>
{
    Task<Inventory?> FindByProductIdAndWarehouseIdAsync(int productId, int warehouseId);
}
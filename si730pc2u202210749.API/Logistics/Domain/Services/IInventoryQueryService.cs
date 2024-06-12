using si730pc2u202210749.API.Logistics.Domain.Model.Aggregates;
using si730pc2u202210749.API.Logistics.Domain.Model.Queries;

namespace si730pc2u202210749.API.Logistics.Domain.Services;

public interface IInventoryQueryService
{
    Task<IEnumerable<Inventory>> Handle(GetAllInventoriesQuery query);
    Task<Inventory?> Handle(GetInventoryByIdQuery query);
    Task<Inventory?> Handle(GetInventoryByProductIdAndWarehouseId query);
}
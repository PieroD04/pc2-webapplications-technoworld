using si730pc2u202210749.API.Logistics.Domain.Model.Aggregates;
using si730pc2u202210749.API.Logistics.Interfaces.REST.Resources;

namespace si730pc2u202210749.API.Logistics.Interfaces.REST.Transform;

public static class InventoryResourceFromEntityAssembler
{
    public static InventoryResource ToResourceFromEntity(Inventory entity)
    {
        return new InventoryResource(entity.Id, entity.InventoryProductId, entity.InventoryWarehouseId, entity.InventoryMinimumStock,
            entity.InventoryCurrentStock, entity.InventoryStatus);
    }
}
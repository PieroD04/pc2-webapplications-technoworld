using si730pc2u202210749.API.Logistics.Domain.Model.Commands;
using si730pc2u202210749.API.Logistics.Interfaces.REST.Resources;

namespace si730pc2u202210749.API.Logistics.Interfaces.REST.Transform;

public static class UpdateInventoryCommandFromResourceAssembler
{
    public static UpdateInventoryCommand ToCommandFromResource(int inventoryId, UpdateInventoryResource resource)
    {
        return new UpdateInventoryCommand(inventoryId, resource.ProductId, resource.WarehouseId, resource.MinimumStock, resource.CurrentStock);
    }
    
}
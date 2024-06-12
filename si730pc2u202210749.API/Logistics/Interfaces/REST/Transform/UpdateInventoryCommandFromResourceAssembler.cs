using si730pc2u202210749.API.Logistics.Domain.Model.Commands;
using si730pc2u202210749.API.Logistics.Interfaces.REST.Resources;

namespace si730pc2u202210749.API.Logistics.Interfaces.REST.Transform;

public static class UpdateInventoryCommandFromResourceAssembler
{
    public static UpdateInventoryCommand ToCommandFromResource(UpdateInventoryResource resource)
    {
        return new UpdateInventoryCommand(resource.Id, resource.ProductId, resource.WarehouseId, resource.MinimumStock, resource.CurrentStock);
    }
    
}
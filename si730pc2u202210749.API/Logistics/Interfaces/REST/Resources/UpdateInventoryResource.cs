namespace si730pc2u202210749.API.Logistics.Interfaces.REST.Resources;

public record UpdateInventoryResource(int Id, int ProductId, int WarehouseId, int MinimumStock, int CurrentStock);
namespace si730pc2u202210749.API.Logistics.Interfaces.REST.Resources;

// Resource is a record with data of a resource and an ID
//Upper Camel Case
public record InventoryResource(int Id, int ProductId, int WarehouseId, int MinimumStock, int CurrentStock);
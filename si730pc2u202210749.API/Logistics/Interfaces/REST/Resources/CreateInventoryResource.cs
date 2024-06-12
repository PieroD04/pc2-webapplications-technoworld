namespace si730pc2u202210749.API.Logistics.Interfaces.REST.Resources;

//Create Resource is a record with data of a resource but without an ID
//Upper Camel Case
public record CreateInventoryResource(int ProductId, int WarehouseId, int MinimumStock, int CurrentStock);
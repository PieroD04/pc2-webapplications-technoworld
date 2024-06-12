namespace si730pc2u202210749.API.Logistics.Domain.Model.Commands;

//Command has attributes from entity without ID
public record CreateInventoryCommand(int ProductId, int WarehouseId, int MinimumStock, int CurrentStock);
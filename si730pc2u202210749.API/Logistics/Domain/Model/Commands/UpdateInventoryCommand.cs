namespace si730pc2u202210749.API.Logistics.Domain.Model.Commands;

public record UpdateInventoryCommand(int Id, int ProductId, int WarehouseId, int MinimumStock, int CurrentStock);
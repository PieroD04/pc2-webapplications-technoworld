using si730pc2u202210749.API.Logistics.Domain.Model.Aggregates;
using si730pc2u202210749.API.Logistics.Domain.Model.Commands;
using si730pc2u202210749.API.Logistics.Domain.Repositories;
using si730pc2u202210749.API.Logistics.Domain.Services;
using si730pc2u202210749.API.Shared.Domain.Repositories;

namespace si730pc2u202210749.API.Logistics.Application.Internal.CommandServices;

public class InventoryCommandService(IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork) : IInventoryCommandService
{
    public async Task<Inventory?> Handle(CreateInventoryCommand command)
    {
        var existingInventory = await inventoryRepository.FindByProductIdAndWarehouseIdAsync(command.ProductId, command.WarehouseId);
        if (existingInventory != null)
        {
            throw new ArgumentException("Inventory with the same ProductId and WarehouseId already exists.");
        }
        
        var inventory = new Inventory(command);
        try
        {
            await inventoryRepository.AddAsync(inventory);
            await unitOfWork.CompleteAsync();
            return inventory;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the inventory: {e.Message}");
            return null;
        }
    }
    
    public async Task<Inventory?> Handle(UpdateInventoryCommand command)
    {
        
        var inventory = await inventoryRepository.FindByIdAsync(command.Id);
        if (inventory == null)
        {
            throw new ArgumentException("InventoryId not found.");
        }
        
        if(inventory.ProductId.ProductId != command.ProductId || inventory.WarehouseId.WarehouseId != command.WarehouseId)
        {
            var existingInventory = await inventoryRepository.FindByProductIdAndWarehouseIdAsync(command.ProductId, command.WarehouseId);
            if (existingInventory != null)
            {
                throw new ArgumentException("Inventory with the same ProductId and WarehouseId already exists.");
            }
        }
        
        inventory.Update(command);
        try
        {
            inventoryRepository.Update(inventory);
            await unitOfWork.CompleteAsync();
            return inventory;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the inventory: {e.Message}");
            return null;
        }
    }
    
    public async Task<Inventory?> Handle(DeleteInventoryCommand command)
    {
        var inventory = await inventoryRepository.FindByIdAsync(command.Id);
        if (inventory == null)
        {
            throw new ArgumentException("InventoryId not found.");
        }
        try
        {
            inventoryRepository.Remove(inventory);
            await unitOfWork.CompleteAsync();
            return inventory;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the inventory: {e.Message}");
            return null;
        }
    }
}
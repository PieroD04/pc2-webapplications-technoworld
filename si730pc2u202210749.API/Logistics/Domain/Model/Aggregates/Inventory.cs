using si730pc2u202210749.API.Logistics.Domain.Model.Commands;
using si730pc2u202210749.API.Logistics.Domain.Model.ValueObjects;

namespace si730pc2u202210749.API.Logistics.Domain.Model.Aggregates;

/// <summary>
/// Represents an inventory item in the logistics system.
/// </summary>
/// <remarks>
/// Piero Delgado
/// </remarks>
public partial class Inventory
{
    /// <summary>
    /// Default constructor for the Inventory class.
    /// </summary>
    public Inventory()
    {
        ProductId = new InvProductId(0);
        WarehouseId = new InvWarehouseId(0);
        MinimumStock = new InvMinimumStock();
        CurrentStock = new InvCurrentStock();
        Type = InvType.Other;
        Status = InvStatus.LimitedStock;
    }
    /// <summary>
    /// Constructs an Inventory object with specified parameters.
    /// </summary>
    /// <param name="productId">The ID of the product.</param>
    /// <param name="warehouseId">The ID of the warehouse.</param>
    /// <param name="minimumStock">The minimum stock of the product.</param>
    /// <param name="currentStock">The current stock of the product.</param>
    /// <param name="type">The type of the inventory item.</param>
    public Inventory(int productId, int warehouseId, int minimumStock, int currentStock, string type)
    {
        if(currentStock < minimumStock)
        {
            throw new Exception("Current stock cannot be less than minimum stock");
        }
        
        ProductId = new InvProductId(productId);
        WarehouseId = new InvWarehouseId(warehouseId);
        MinimumStock = new InvMinimumStock(minimumStock);
        CurrentStock = new InvCurrentStock(currentStock);
        
        try
        {
            Type = (InvType)Enum.Parse(typeof(InvType), type, true);
        }
        catch
        {
            throw new Exception("Invalid inventory type. Must be Food, Beverage, Medicine, Electronics, Clothing, Furniture, Other");
        }
        
        UpdateStatus();
    }
    /// <summary>
    /// Constructs an Inventory object with the data of the create command.
    /// </summary>
    public Inventory(CreateInventoryCommand command)
    {
        if(command.CurrentStock < command.MinimumStock)
        {
            throw new Exception("Current stock cannot be less than minimum stock");
        }
        
        ProductId = new InvProductId(command.ProductId);
        WarehouseId = new InvWarehouseId(command.WarehouseId);
        MinimumStock = new InvMinimumStock(command.MinimumStock);
        CurrentStock = new InvCurrentStock(command.CurrentStock);
        
        try
        {
            Type = (InvType)Enum.Parse(typeof(InvType), command.Type, true);
        }
        catch
        {
            throw new Exception("Invalid inventory type. Must be Food, Beverage, Medicine, Electronics, Clothing, Furniture, Other");
        }
        
        UpdateStatus();
    }
    
    /// <summary>
    /// Updates the inventory item with the specified command.
    /// </summary>
    /// <param name="command">The command that has the data to update the inventory item.</param>
    public void Update(UpdateInventoryCommand command)
    {
        if(command.CurrentStock < command.MinimumStock)
        {
            throw new Exception("Current stock cannot be less than minimum stock");
        }

        ProductId = new InvProductId(command.ProductId);
        WarehouseId = new InvWarehouseId(command.WarehouseId);
        MinimumStock = new InvMinimumStock(command.MinimumStock);
        CurrentStock = new InvCurrentStock(command.CurrentStock);
        
        try
        {
            Type = (InvType)Enum.Parse(typeof(InvType), command.Type, true);
        }
        catch
        {
            throw new Exception("Invalid inventory type. Must be Food, Beverage, Medicine, Electronics, Clothing, Furniture, Other");
        }
        
        UpdateStatus();
    }
    
    /// <summary>
    /// Updates the status of the inventory item based on the current stock and minimum stock.
    /// </summary>
    private void UpdateStatus()
    {
        if(MinimumStock.MinimumStock == CurrentStock.CurrentStock)
        {
            Status = InvStatus.LimitedStock;
        }
        else if(CurrentStock.CurrentStock > MinimumStock.MinimumStock * 2)
        {
            Status = InvStatus.OverStock;
        }
        else
        {
            Status = InvStatus.InStock;
        }
    }
    
    public int Id { get; set; }
    public InvProductId ProductId { get; set; }
    public InvWarehouseId WarehouseId { get; set; }
    public InvMinimumStock MinimumStock { get; set; }
    public InvCurrentStock CurrentStock { get; set; }
    public InvStatus Status { get; set; }
    public InvType Type { get; set; }
    
    public int InventoryProductId => ProductId.ProductId;
    public int InventoryWarehouseId => WarehouseId.WarehouseId;
    public int InventoryMinimumStock => MinimumStock.MinimumStock;
    public int InventoryCurrentStock => CurrentStock.CurrentStock;
    public string InventoryStatus => Status.ToString();
    public string InventoryType => Type.ToString();
}
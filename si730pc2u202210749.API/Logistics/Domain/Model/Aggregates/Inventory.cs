using si730pc2u202210749.API.Logistics.Domain.Model.Commands;
using si730pc2u202210749.API.Logistics.Domain.Model.ValueObjects;

namespace si730pc2u202210749.API.Logistics.Domain.Model.Aggregates;

public partial class Inventory
{
    //Constructor por defecto
    public Inventory()
    {
        ProductId = new InvProductId(0);
        WarehouseId = new InvWarehouseId(0);
        MinimumStock = new InvMinimumStock();
        CurrentStock = new InvCurrentStock();
        Status = InvStatus.LimitedStock;
    }
    //Constructor por parametros
    public Inventory(int productId, int warehouseId, int minimumStock, int currentStock)
    {
        if(currentStock < minimumStock)
        {
            throw new Exception("Current stock cannot be less than minimum stock");
        }
        
        ProductId = new InvProductId(productId);
        WarehouseId = new InvWarehouseId(warehouseId);
        MinimumStock = new InvMinimumStock(minimumStock);
        CurrentStock = new InvCurrentStock(currentStock);
        
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
    //Constructor por comandos
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
    
    public int InventoryProductId => ProductId.ProductId;
    public int InventoryWarehouseId => WarehouseId.WarehouseId;
    public int InventoryMinimumStock => MinimumStock.MinimumStock;
    public int InventoryCurrentStock => CurrentStock.CurrentStock;
    public string InventoryStatus => Status.ToString();
}
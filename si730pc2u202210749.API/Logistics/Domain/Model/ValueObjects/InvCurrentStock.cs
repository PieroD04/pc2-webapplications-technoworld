namespace si730pc2u202210749.API.Logistics.Domain.Model.ValueObjects;

public class InvCurrentStock
{
    public int CurrentStock { get; private set; }
    
    public InvCurrentStock()
    {
        CurrentStock = 1;
    }

    public InvCurrentStock(int currentStock)
    {
        CurrentStock = currentStock;
    }
}
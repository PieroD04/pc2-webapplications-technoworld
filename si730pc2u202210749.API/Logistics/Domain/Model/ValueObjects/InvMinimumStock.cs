namespace si730pc2u202210749.API.Logistics.Domain.Model.ValueObjects;

public class InvMinimumStock
{
    public int MinimumStock { get; set; }
    public InvMinimumStock()
    {
        MinimumStock = 1;
    }
    
    public InvMinimumStock(int minimumStock)
    {
        if (minimumStock < 1)
        {
            throw new ArgumentException("Minimum stock cannot be lower than 1");
        }
        MinimumStock = minimumStock;
    }

}
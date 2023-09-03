namespace MaterialAllergenManagementApp.Allergens;

public class Stock
{
    public UnitOfMeasure UnitOfMeasure { get; private set; }
    public decimal CurrentAvailableStock { get; private set; }

    // for EF
    protected Stock()
    {
        
    }

    private Stock(UnitOfMeasure unitOfMeasure, decimal initialStock)
    {
        UnitOfMeasure = unitOfMeasure;
        CurrentAvailableStock = initialStock;
    }

    public static Stock CreateInitialStock(UnitOfMeasure unitOfMeasure, decimal initialStock) =>
        new(unitOfMeasure, initialStock);
}
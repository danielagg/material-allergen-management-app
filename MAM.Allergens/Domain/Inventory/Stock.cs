using MAM.Allergens.Domain.Exceptions;

namespace MAM.Allergens.Domain.Inventory;

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

    public static Stock CreateInitialStock(UnitOfMeasure unitOfMeasure, decimal initialStock)
    {
        if(unitOfMeasure is null)
            throw new MissingUnitOfMeasureException();

        if(initialStock < 0)
            throw new InvalidInitialStockException();

        return new(unitOfMeasure, initialStock);
    }
}
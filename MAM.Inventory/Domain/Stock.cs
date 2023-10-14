using MAM.Inventory.Domain.Exceptions;
using MAM.Shared.Domain;

namespace MAM.Inventory.Domain;

public class Stock : Entity
{
    public UnitOfMeasure UnitOfMeasure { get; private set; }
    public decimal CurrentAvailableStock { get; private set; }

    // for EF
    protected Stock()
    {
        
    }

    private Stock(UnitOfMeasure unitOfMeasure, decimal initialStock) : base()
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
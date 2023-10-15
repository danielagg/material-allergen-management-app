using MAM.Inventory.Domain.Exceptions;
using MAM.Shared.Domain;

namespace MAM.Inventory.Domain;

public class Stock : Entity
{
    public string MaterialId { get; private set; }
    public UnitOfMeasure UnitOfMeasure { get; private set; }
    public decimal CurrentAvailableStock { get; private set; }

    // for EF (requires a param-less ctor)
    protected Stock()
    {
        
    }

    private Stock(string materialId, UnitOfMeasure unitOfMeasure, decimal initialStock) : base()
    {
        MaterialId = materialId;
        UnitOfMeasure = unitOfMeasure;
        CurrentAvailableStock = initialStock;
    }

    public static Stock CreateInitialStock(string materialId, UnitOfMeasure unitOfMeasure, decimal initialStock)
    {
        if(unitOfMeasure is null)
            throw new MissingUnitOfMeasureException();

        if(initialStock < 0)
            throw new InvalidInitialStockException();

        return new(materialId, unitOfMeasure, initialStock);
    }
}
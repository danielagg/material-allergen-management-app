using MediatR;

namespace MAM.Inventory.UseCases.InitializeInventory;

public class InitializeInventoryCommand : IRequest
{
    public string MaterialCode { get; }
    public string UnitOfMeasureCode { get; }
    public string UnitOfMeasureName { get; }
    public decimal InitialStock { get; }
    
    public InitializeInventoryCommand(
        string materialCode,
        string unitOfMeasureCode,
        string unitOfMeasureName,
        decimal initialStock)
    {
        MaterialCode = materialCode;
        UnitOfMeasureCode = unitOfMeasureCode;
        UnitOfMeasureName = unitOfMeasureName;
        InitialStock = initialStock;
    }
}
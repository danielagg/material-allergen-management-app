using MediatR;

namespace MAM.Shared.GlobalEvents;

public class NewMaterialCreated : INotification
{
    public string Id { get; }
    public string Name { get; }
    public string UnitOfMeasureCode { get; }
    public string UnitOfMeasureName { get; }
    public decimal InitialStock { get; }

    public NewMaterialCreated(
        string id,
        string name,
        string unitOfMeasureCode,
        string unitOfMeasureName,
        decimal initialStock)
    {
        Id = id;
        Name = name;
        UnitOfMeasureCode = unitOfMeasureCode;
        UnitOfMeasureName = unitOfMeasureName;
        InitialStock = initialStock;
    }
}

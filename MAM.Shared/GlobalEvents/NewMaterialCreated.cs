using MediatR;

namespace MAM.Shared.GlobalEvents;

public class NewMaterialCreated : INotification
{
    public string Id { get; }
    public string Name { get; }
    public string UnitOfMeasureCode { get; }
    public string UnitOfMeasureName { get; }
    public decimal InitialStock { get; }
    public List<string> AllergensByNature { get; }
    public List<string> AllergensByCrossContamination { get; }

    public NewMaterialCreated(
        string id,
        string name,
        string unitOfMeasureCode,
        string unitOfMeasureName,
        decimal initialStock,
        List<string> allergensByNature,
        List<string> allergensByCrossContamination)
    {
        Id = id;
        Name = name;
        UnitOfMeasureCode = unitOfMeasureCode;
        UnitOfMeasureName = unitOfMeasureName;
        InitialStock = initialStock;
        AllergensByNature = allergensByNature;
        AllergensByCrossContamination = allergensByCrossContamination;
    }
}

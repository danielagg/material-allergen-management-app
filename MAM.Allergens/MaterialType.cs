using MAM.Shared.Domain;

namespace MAM.Allergens;

public class MaterialType : Entity
{
    public string Name { get; }
    public List<MaterialCategory> ApplicableFor { get; } = new List<MaterialCategory>();

    // for EF
    protected MaterialType()
    {
        
    }

    private MaterialType(string id, string name, List<MaterialCategory> applicableFor, DateTime createdOn)
    {
        Id = id;
        Name = name;
        ApplicableFor = applicableFor;
        CreatedOn = createdOn;
    }

    public static MaterialType Create(string id, string name, List<MaterialCategory> applicableFor, DateTime createdOn) =>
        new(id, name, applicableFor, createdOn);
}
using LanguageExt.Common;
using MAM.Materials.Domain.MaterialClassification;
using MAM.Shared.Domain;

namespace MAM.Materials.Domain;

public class Material : Entity
{
    public MaterialCode Code { get; private set; }
    public MaterialName Name { get; private set; }
    public MaterialType Type { get; private set; }

    // for EF (requires a param-less ctor)
    protected Material()
    {
        
    }

    private Material(
        MaterialCode code,
        MaterialName name,
        MaterialType materialType
    ) : base()
    {
        Code = code;
        Name = name;
        Type = materialType;
    }

    public static Result<Material> Create(
        MaterialCode code,
        MaterialName name,
        MaterialType materialType
    )
    {
        return new Material(code, name, materialType);
    }
}

using MAM.Allergens.Domain.Exceptions;

namespace MAM.Allergens.Domain;

public class MaterialName
{
    public string ShortName { get; private set; }
    public string FullName { get; private set; }

    // for EF
    protected MaterialName()
    {
        
    }

    private MaterialName(string shortName, string fullName)
    {
        ShortName = shortName;
        FullName = fullName;
    }

    public static MaterialName Create(string shortName, string fullName)
    {
        if (string.IsNullOrWhiteSpace(shortName))
            throw new InvalidMaterialNameException("The short name of the material cannot be empty");

        if (string.IsNullOrWhiteSpace(fullName))
            throw new InvalidMaterialNameException("The full name of the material cannot be empty");
        
        return new(shortName, fullName);
    }
}
using MAM.Allergens.Domain.Exceptions;

namespace MAM.Allergens.Domain;

public class MaterialCode
{
    public string Value { get; private set; }

    // for EF
    protected MaterialCode()
    {
        
    }

    private MaterialCode(string value)
    {
        Value = value;
    }

    public static MaterialCode Create(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new InvalidMaterialCodeException("Material code cannot be empty");

        var trimmedCode = code.Trim();

        if (trimmedCode.Length != 6)
            throw new InvalidMaterialCodeException("Material code must be 6 characters long");

        if (!trimmedCode.StartsWith('P') && !trimmedCode.StartsWith('R'))
            throw new InvalidMaterialCodeException("Material code must start with P or R");

        return new(trimmedCode);
    }
}
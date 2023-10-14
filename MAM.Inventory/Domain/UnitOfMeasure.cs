using MAM.Inventory.Domain.Exceptions;

namespace MAM.Inventory.Domain;

public class UnitOfMeasure
{
    public string Code { get; private set; }
    public string Name { get; private set; }

    // for EF
    protected UnitOfMeasure()
    {
        
    }

    private UnitOfMeasure(string code, string name)
    {
        Code = code;
        Name = name;   
    }

    public static UnitOfMeasure Create(string code, string name)
    {
        if(string.IsNullOrWhiteSpace(code))
            throw new InvalidUnitOfMeasureException("Unit of measure code is mandatory.");

        if(string.IsNullOrWhiteSpace(name))
            throw new InvalidUnitOfMeasureException("Unit of measure name is mandatory.");

        return new(code.Trim(), name.Trim());
    }
}
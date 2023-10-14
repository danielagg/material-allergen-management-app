namespace MAM.Shared.GlobalEvents;

public class NewMaterialCreated
{
    public string Id { get; }
    public string Name { get; }
    public string UnitOfMeasure { get; }
}
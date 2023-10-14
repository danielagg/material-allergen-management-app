using MediatR;

namespace MAM.Shared.GlobalEvents;

public class MaterialDeleted : INotification
{
    public string Id { get; }

    public MaterialDeleted(string id)
    {
        Id = id;
    }
}
using MediatR;

namespace MAM.Allergens.UseCases.DeleteMaterial;

public class DeleteMaterialCommand : IRequest
{
    public string MaterialCode { get; }

    public DeleteMaterialCommand(string materialCode)
    {
        MaterialCode = materialCode;
    }
}
using MediatR;

namespace MAM.Materials.UseCases.DeleteMaterial;

public class DeleteMaterialCommand : IRequest
{
    public string MaterialId { get; }

    public DeleteMaterialCommand(string materialId)
    {
        MaterialId = materialId;
    }
}
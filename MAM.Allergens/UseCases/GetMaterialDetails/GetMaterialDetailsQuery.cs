using MediatR;

namespace MAM.Allergens.UseCases.GetMaterialDetails;

public class GetMaterialDetailsQuery : IRequest<MaterialAllergenDetailsDto>
{
    public string MaterialCode { get; }

    public GetMaterialDetailsQuery(string materialCode)
    {
        MaterialCode = materialCode;
    }
}
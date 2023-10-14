using MediatR;

namespace MAM.Allergens.UseCases.GetAllergenClassificationDetails;

public class GetAllergenClassificationDetailsQuery : IRequest<AllergenClassificationDetailsDto>
{
    public string MaterialId { get; }

    public GetAllergenClassificationDetailsQuery(string materialId)
    {
        MaterialId = materialId;
    }
}
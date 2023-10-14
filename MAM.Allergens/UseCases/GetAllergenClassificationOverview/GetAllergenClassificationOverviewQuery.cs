using MediatR;

namespace MAM.Allergens.UseCases.GetAllergenClassificationOverview;

public class GetAllergenClassificationOverviewQuery : IRequest<List<AllergenClassificationOverviewDto>>
{
    public IEnumerable<string> MaterialIds { get; }

    public GetAllergenClassificationOverviewQuery(IEnumerable<string> materialIds)
    {
        MaterialIds = materialIds;
    }
}
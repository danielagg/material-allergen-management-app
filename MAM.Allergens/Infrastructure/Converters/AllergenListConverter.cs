using MAM.Allergens.Domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAM.Allergens.Infrastructure.Converters;

public class AllergenListConverter : ValueConverter< List<IndividualAllergen>, string>
{
    public AllergenListConverter()
        : base(
            v => string.Join(';', v.Select(vv => vv.Name)),
            v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(a => new IndividualAllergen(a)).ToList())
    {
    }
}
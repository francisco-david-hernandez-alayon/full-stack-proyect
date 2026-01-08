using GameApp.Adapter.Infrastructure.Models;
using GameApp.Domain.ValueObjects.Combat;

namespace GameApp.Adapter.Infrastructure.Mappers;

public static class CriticalDamageDtoMapper
{
    public static CriticalDamageDto ToDto(CriticalDamage cd)
    {
        return new CriticalDamageDto
        {
            CriticalProbability = cd.GetCriticalProbability(),
            ExtraDamage = cd.GetExtraDamage(),
        };
    }

    public static CriticalDamage ToDomain(CriticalDamageDto doc)
    {
        if (doc == null)
        {
            throw new ArgumentNullException(nameof(doc));
        }
            
        return new CriticalDamage(doc.CriticalProbability, doc.ExtraDamage);
    }

}

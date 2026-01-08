using GameApp.Domain.ValueObjects.Characters;
using GameApp.Adapter.Infrastructure.Models;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.ValueObjects.Items;
using GameApp.Domain.Repositories;
using GameApp.Application.Enumerates;
using GameApp.Domain.ValueObjects.Combat;

namespace GameApp.Adapter.Infrastructure.Mappers;

public static class CriticalDamageDocumentMapper
{
    public static CriticalDamageDocument ToDocument(CriticalDamage cd)
    {
        return new CriticalDamageDocument
        {
            CriticalProbability = cd.GetCriticalProbability(),
            ExtraDamage = cd.GetExtraDamage(),
        };
    }

    public static CriticalDamage ToDomain(CriticalDamageDocument doc)
    {
        if (doc == null)
            throw new ArgumentNullException(nameof(doc));
        return new CriticalDamage(doc.CriticalProbability, doc.ExtraDamage);
    }

}

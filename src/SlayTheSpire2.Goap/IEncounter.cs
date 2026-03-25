using System;
using System.Collections.Generic;
using System.Linq;

namespace SlayTheSpire2.Goap
{
    public interface IEncounter
    {
        EncounterType EncounterType { get; }

        string Name { get; }

        IReadOnlyList<IEnemyArchetype> Archetypes { get; }

        IEnumerable<Enemy> CreateOpponents(Ascension ascension)
        {
            var random = new Random();
            return Archetypes.Select(archetype =>
            {
                var (min, max) = archetype.HPRange(ascension);
                return archetype.CreateEnemy((ushort)random.Next(min, max), ascension);
            });
        }
    }
}

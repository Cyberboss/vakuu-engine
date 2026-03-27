using System;
using System.Collections.Generic;

namespace Vakuu.Engine
{
    public interface IEncounter
    {
        EncounterType EncounterType { get; }

        string Name { get; }

        IReadOnlyList<IEnemyArchetype> Archetypes { get; }

        IEnumerable<Enemy> CreateOpponents(IReadOnlyList<ushort> knownHPs, Ascension ascension)
        {
            ArgumentNullException.ThrowIfNull(knownHPs);
            if (knownHPs.Count != Archetypes.Count)
                throw new ArgumentOutOfRangeException(nameof(knownHPs), knownHPs.Count, $"Expected {Archetypes.Count} HP values for instantiating enemies!");

            for (var i = 0; i < Archetypes.Count; ++i)
                yield return Archetypes[i].CreateEnemy(knownHPs[i], ascension);
        }
    }
}

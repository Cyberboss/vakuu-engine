using System.Collections.Generic;

namespace SlayTheSpire.Goap
{
    public interface IEncounter
    {
        EncounterType EncounterType { get; }

        string Name { get; }

        IEnumerable<Enemy> CreateOpponents();
    }
}

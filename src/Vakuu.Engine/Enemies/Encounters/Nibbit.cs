using System.Collections.Generic;

namespace Vakuu.Engine.Enemies.Encounters
{
    public sealed class Nibbit : IEncounter
    {
        public Nibbit()
        {
            Archetypes = new List<IEnemyArchetype>
            {
                new Enemies.Nibbit(0),
            };
        }

        public string Name => "Nibbit";

        public EncounterType EncounterType => EncounterType.Enemy;

        public IReadOnlyList<IEnemyArchetype> Archetypes { get; }
    }
}

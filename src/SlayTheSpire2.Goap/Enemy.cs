using System;
using System.Collections.Generic;

namespace SlayTheSpire.Goap
{
    public sealed class Enemy : Combatant
    {
        public Enemy(IEnumerable<IStatus> statuses, Health health)
            : base(statuses, health)
        {
        }

        public Guid ID { get; init; }
        public IEnemyArchetype Archetype { get; }
        public IReadOnlyCollection<IEnemyMove> UpcomingMoves { get; }
    }
}

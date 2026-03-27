using System;
using System.Collections.Generic;
using System.Threading;

namespace Vakuu.Engine
{
    public sealed class Enemy : Combatant
    {
        static ulong IDAllocator;

        readonly Queue<IEnemyMove> upcomingMoves;

        public Enemy(IEnemyArchetype archetype)
        {
            Archetype = archetype ?? throw new ArgumentNullException(nameof(archetype));
            upcomingMoves = new Queue<IEnemyMove>(archetype.Moveset);
            ID = Interlocked.Increment(ref IDAllocator);
        }

        public ulong ID { get; init; }
        public IEnemyArchetype Archetype { get; }
        public IReadOnlyCollection<IEnemyMove> UpcomingMoves => upcomingMoves;

        public override string HealthState => throw new NotImplementedException();

        public override string MaxHealthState => throw new NotImplementedException();

        public override string ToString() => $"{Archetype.Name} ({ID})";

        public void CycleMoveset()
            => upcomingMoves.Enqueue(upcomingMoves.Dequeue());
        public override string StatusState(IStatus status) => throw new NotImplementedException();
    }
}

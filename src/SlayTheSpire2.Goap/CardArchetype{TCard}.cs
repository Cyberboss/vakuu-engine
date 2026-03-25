using System;

namespace SlayTheSpire.Goap
{
    public abstract class CardArchetype<TCard> : ICardArchetype
        where TCard : CardArchetype<TCard>, new()
    {
        static readonly Lazy<TCard> Singleton = new Lazy<TCard>(() => new TCard());

        public static TCard Instance => Singleton.Value;
        public abstract string Name { get; }

        public abstract CardType Type { get; }
        public abstract CardPool Pool { get; }
        public abstract bool EnemyTargeted { get; }

        public abstract byte EnergyCost(bool upgraded);
    }
}

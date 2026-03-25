namespace SlayTheSpire2.Goap
{
    public abstract class CardArchetype<TCard> : Singleton<TCard>, ICardArchetype
        where TCard : CardArchetype<TCard>, new()
    {
        public abstract string Name { get; }

        public abstract CardType Type { get; }
        public abstract CardPool Pool { get; }
        public abstract bool EnemyTargeted { get; }

        public abstract byte EnergyCost(bool upgraded);
    }
}

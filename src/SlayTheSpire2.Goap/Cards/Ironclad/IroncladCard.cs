namespace SlayTheSpire2.Goap.Cards.Ironclad
{
    public abstract class IroncladCard<TCard> : CardArchetype<TCard>
        where TCard : IroncladCard<TCard>, new()
    {
        public override CardPool Pool => CardPool.Ironclad;
    }
}
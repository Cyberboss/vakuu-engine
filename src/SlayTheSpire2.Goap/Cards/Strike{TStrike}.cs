namespace SlayTheSpire2.Goap.Cards
{
    public abstract class Strike<TStrike> : CardArchetype<TStrike>
        where TStrike : Strike<TStrike>, new()
    {
        public override string Name => "Strike";

        public override CardType Type => CardType.Attack;

        public override bool EnemyTargeted => true;

        public override byte EnergyCost(bool upgraded) => 1;

        public ushort Damage(bool upgraded)
            => (ushort)(upgraded
                ? 9
                : 6);
    }
}

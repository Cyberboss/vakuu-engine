namespace SlayTheSpire.Goap.Cards.Ironclad
{
    public sealed class Bash : IroncladCard<Bash>
    {
        public override string Name => "Bash";

        public override CardType Type => CardType.Attack;

        public override bool EnemyTargeted => true;

        public override byte EnergyCost(bool upgraded) => 2;

        public ushort Damage(bool upgraded)
            => (ushort)(upgraded
                ? 10
                : 8);
    }
}

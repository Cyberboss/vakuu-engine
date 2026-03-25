namespace SlayTheSpire.Goap
{
    public interface IStatus
    {
        public string Name { get; }
        public short Amount { get; }

        bool Adjust(short amount);

        short ModifyDamage(short damage) => damage;
        bool? TryMergeInto(IStatus other);
        bool OnTurnStart(byte turnIndex) => true;
        bool OnCardPlayed(FieldCard card) => true;
        bool OnAttacked(Combatant attacker, Combatant defender) => true;
        bool OnTurnEnd(byte turnIndex) => true;
    }
}
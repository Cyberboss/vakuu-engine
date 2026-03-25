namespace SlayTheSpire.Goap.Statuses
{
    internal sealed class Vulnerable : CountdownStatus<Vulnerable>
    {
        public Vulnerable(short amount)
            : base(amount)
        {
        }

        public override string Name => "Vulnerable";
    }
}

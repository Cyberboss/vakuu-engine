namespace SlayTheSpire.Goap
{
    internal abstract class CountdownStatus<TImplementation> : Status<TImplementation>
        where TImplementation : IStatus
    {
        protected CountdownStatus(short amount) : base(amount)
        {
        }

        public bool OnTurnEnd(byte turnIndex)
            => Adjust(-1);
    }
}

namespace SlayTheSpire.Goap.Statuses
{
    internal sealed class Block : Status<Block>
    {
        public Block(short amount)
            : base(amount)
        {
        }

        public override string Name => "Block";
    }
}

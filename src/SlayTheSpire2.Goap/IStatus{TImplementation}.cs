using System;

namespace SlayTheSpire.Goap
{
    internal abstract class Status<TImplementation> : IStatus
        where TImplementation : IStatus
    {
        public Status(short amount)
        {
            if (amount == 0)
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Must be greater than zero!");

            Amount = amount;
        }
        public abstract string Name { get; }

        public short Amount { get; private set; }

        public bool Adjust(short amount)
        {
            Amount += amount;
            return Amount > 0;
        }

        public bool? TryMergeInto(IStatus other)
        {
            if (other is TImplementation otherImplementation)
                return Adjust(otherImplementation.Amount);

            return null;
        }
    }
}

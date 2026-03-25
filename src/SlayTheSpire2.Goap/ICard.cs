using System.Collections.Generic;

namespace SlayTheSpire.Goap
{
    public interface ICard
    {
        ICardArchetype Archetype { get; }

        bool Upgraded { get; }

        void Upgrade();

        HashSet<CardModifier> GetModifiers();
    }
}
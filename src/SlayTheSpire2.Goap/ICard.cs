using System.Collections.Generic;

namespace SlayTheSpire2.Goap
{
    public interface ICard
    {
        ICardArchetype Archetype { get; }

        bool Upgraded { get; }

        void Upgrade();

        HashSet<CardModifier> GetModifiers();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace SlayTheSpire.Goap
{
    public sealed class Card : ICard
    {
        public ICardArchetype Archetype { get; }

        public bool Upgraded { get; private set; }

        readonly HashSet<CardModifier> additionalModifiers;

        public Card(ICardArchetype archetype, bool upgraded = false)
        {
            Archetype = archetype ?? throw new ArgumentNullException(nameof(archetype));
            additionalModifiers = new HashSet<CardModifier>();
            Upgraded = upgraded;
        }

        public HashSet<CardModifier> GetModifiers()
            => Archetype
                .Modifiers(Upgraded)
                .Concat(additionalModifiers)
                .ToHashSet();

        public void Upgrade()
        {
            Upgraded = true;
        }
    }
}
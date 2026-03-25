using System;
using System.Collections.Generic;

namespace SlayTheSpire2.Goap
{
    public sealed class FieldCard : ICard
    {
        readonly Card deckCard;
        readonly HashSet<CardModifier> additionalModifiers;

        public FieldCard(Card deckCard)
            : this(deckCard, null, deckCard.Upgraded)
        {
        }

        private FieldCard(Card deckCard, HashSet<CardModifier>? additionalModifiers, bool upgraded)
        {
            this.deckCard = deckCard;
            this.additionalModifiers = additionalModifiers != null
                ? new HashSet<CardModifier>(additionalModifiers)
                : new HashSet<CardModifier>();
            ID = Guid.NewGuid();
            Upgraded = upgraded;
        }

        public Guid ID { get; init; }

        public ICardArchetype Archetype => deckCard.Archetype;

        public bool Upgraded { get; private set; }

        public void Upgrade() => deckCard.Upgrade();

        public HashSet<CardModifier> GetModifiers()
        {
            var baseResult = deckCard.GetModifiers();
            baseResult.UnionWith(additionalModifiers);
            return baseResult;
        }

        public FieldCard Duplicate()
        {
            var result = new FieldCard(deckCard, additionalModifiers, Upgraded);
            return result;
        }
    }
}

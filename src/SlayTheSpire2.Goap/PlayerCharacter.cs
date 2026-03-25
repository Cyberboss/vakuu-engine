using System;
using System.Collections.Generic;
using System.Linq;

using SlayTheSpire2.Goap.Cards.Ironclad;

namespace SlayTheSpire2.Goap
{
    public sealed class PlayerCharacter : Combatant
    {
        public Character Character { get; }

        public List<IArtifact> Artifacts { get; }

        public List<Card> Deck { get; }

        public PlayerCharacter(Health health, Character character)
            : base(Enumerable.Empty<IStatus>(), health)
        {
            Artifacts = new List<IArtifact>(1);
            Deck = new List<Card>(10);
            Character = character;

            var baseCardEnumerable = Enumerable.Repeat<object?>(null, 4);

            Deck.AddRange(Enumerable.Repeat<object?>(null, 6).Select(_ => new Card(Cards.Ironclad.Strike.Instance)));
            Deck.AddRange(Enumerable.Repeat<object?>(null, 4).Select(_ => new Card(Cards.Ironclad.Defend.Instance)));
            Deck.Add(new Card(Bash.Instance));

            switch (character)
            {
                case Character.Ironclad:
                default:
                    throw new NotImplementedException($"No initial deck for {character}!");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

using Vakuu.Engine.Cards.Ironclad;

namespace Vakuu.Engine
{
    public sealed class PlayerCharacter : Combatant
    {
        public Character Character { get; }

        public List<IRelic> Artifacts { get; }

        public List<Card> Deck { get; }

        public override string HealthState => State.PlayerCurrentHealth;

        public override string MaxHealthState => State.PlayerMaxHealth;

        public PlayerCharacter(Character character)
        {
            Artifacts = new List<IRelic>(1);
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

        public override string StatusState(IStatus status) => throw new NotImplementedException();
    }
}

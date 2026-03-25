using System;
using System.Collections.Generic;
using System.Linq;

using MountainGoap;

using SlayTheSpire2.Goap.Goals;

namespace SlayTheSpire2.Goap
{
    public sealed class BattleAI
    {
        readonly PlayerCharacter character;
        readonly List<Enemy> enemies;

        readonly Dictionary<Guid, FieldCard> cards;

        readonly List<Guid> drawPile;
        readonly List<Guid> discards;
        readonly List<Guid> exhausts;

        readonly Agent agent;

        public BattleAI(
            IEnumerable<Enemy> enemies,
            IEncounter encounter,
            PlayerCharacter character,
            Config config)
        {
            this.enemies = enemies?.ToList() ?? throw new ArgumentNullException(nameof(enemies));
            ArgumentNullException.ThrowIfNull(encounter);
            this.character = character ?? throw new ArgumentNullException(nameof(character));

            ArgumentNullException.ThrowIfNull(config);

            cards = character
                .Deck
                .Select(card => new FieldCard(card))
                .ToDictionary(fieldCard => fieldCard.ID);
            agent = new Agent(
                $"Encounter {encounter.EncounterType}: {encounter.Name}",
                goals: new List<BaseGoal>
                {
                    new Survive(config.Survive),
                    new WinEncounter(config.Win),
                    new DontOverheal(config.DontOverheal, character.Health.Max),
                    new MaximizeHP(config.MaximizeHP),
                    new DontLoseMaxHP(config.PreserveMaxHP),
                    new MaximizeDosh(config.MaximizeDosh),
                    new MaintainPotions(config.MaintainPotions),
                });

            this.drawPile = new List<Guid>();
            this.discards = new List<Guid>();
            this.exhausts = new List<Guid>();
        }

        public IReadOnlyDictionary<Guid, FieldCard> Cards => cards;

        public float EvaluateFightCost()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Guid> GetBestTurn(IReadOnlyCollection<Guid> hand)
        {
            throw new NotImplementedException();
        }
    }
}

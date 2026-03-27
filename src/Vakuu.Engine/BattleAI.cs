using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

using MountainGoap;

using Vakuu.Engine.Goals;

namespace Vakuu.Engine
{
    public sealed class BattleAI
    {
        readonly PlayerCharacter character;
        readonly List<Enemy> enemies;

        readonly Dictionary<ulong, FieldCard> cards;
        readonly List<List<FieldCard>> equivalenceGroups;

        readonly List<Guid> drawPile;
        readonly List<Guid> discards;
        readonly List<Guid> exhausts;

        readonly List<MountainGoap.Action> endTurnActions;

        readonly Agent agent;

        Play nextPlay;

        public BattleAI(
            IEnumerable<ushort> enemiesHPs,
            IEncounter encounter,
            Config config,
            PlayerCharacter character,
            Health playerHealth,
            Ascension ascension)
        {
            ArgumentNullException.ThrowIfNull(encounter);
            ArgumentNullException.ThrowIfNull(config);
            this.character = character ?? throw new ArgumentNullException(nameof(character));

            var state = new ConcurrentDictionary<string, object?>
            {
                { character.HealthState, playerHealth.Current },
                { character.MaxHealthState, playerHealth.Max },
                { State.CardDraw, Constants.BaseCardDraw },
                { State.TurnNumber, 1 },
            };

            var bakedEnemyHPs = enemiesHPs.ToList();
            enemies = encounter.CreateOpponents(bakedEnemyHPs, ascension).ToList();
            for (var i = 0; i < bakedEnemyHPs.Count; ++i)
            {
                var enemy = enemies[i];
                var hp = bakedEnemyHPs[i];
                state.Add(enemy.HealthState, hp);
                state.Add(enemy.MaxHealthState, hp);
            }

            state.Add(State.EnemiesAlive, bakedEnemyHPs.Count);

            void SetPlay(Play play) => nextPlay = play;

            equivalenceGroups = new List<List<FieldCard>>();
            var actions = new List<MountainGoap.Action>();
            cards = character
                .Deck
                .Select(card =>
                {
                    var fieldCard = new FieldCard(SetPlay, card);
                    state.Add(fieldCard.InHandState, false);
                    actions.AddRange(fieldCard.GenerateActions(enemies));

                    foreach (var group in equivalenceGroups)
                    {
                        if (fieldCard.EquivalentTo(group[0]))
                        {
                            group.Add(fieldCard);
                            return fieldCard;
                        }
                    }

                    equivalenceGroups.Add(new List<FieldCard>
                    {
                        fieldCard
                    });
                    return fieldCard;
                })
                .ToDictionary(fieldCard => fieldCard.ID);
            agent = new Agent(
                $"Encounter {encounter.EncounterType}: {encounter.Name}",
                goals: new List<BaseGoal>
                {
                    new WinAndSurvive(config.WinAndSurvive),
                    new DontOverheal(config.DontOverheal, playerHealth.Max),
                    new MaximizeHP(config.MaximizeHP),
                    new DontLoseMaxHP(config.PreserveMaxHP),
                    new MaximizeDosh(config.MaximizeDosh),
                    new MaintainPotions(config.MaintainPotions),
                },
                state: state);

            drawPile = new List<Guid>();
            discards = new List<Guid>();
            exhausts = new List<Guid>();
            endTurnActions = new List<MountainGoap.Action>();
        }

        public IReadOnlyDictionary<ulong, FieldCard> Cards => cards;

        public float EvaluateFightCost()
        {
            throw new NotImplementedException();
        }

        public void UpdateHand(IReadOnlyCollection<ulong> hand)
        {
            foreach (var kvp in cards)
                agent.State[kvp.Value.InHandState] = hand.Contains(kvp.Key);

            agent.State[State.HandSize] = hand.Count;

            agent.PlanAsync();
        }

        public Play GetBestMove()
        {
            var endTurnAction = new MountainGoap.Action(
                "End Turn",
                cost: 0.0f,
                executor: (_, _) =>
                {
                    nextPlay = new Play
                    {
                        Name = "End Turn",
                        CardID = null,
                        TargetIDs = Array.Empty<ulong>(),
                    };
                    return ExecutionStatus.Succeeded;
                });

            agent.Step(StepMode.OneAction);
            return nextPlay!;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Vakuu.Engine
{
    public sealed class FieldCard : ICard
    {
        static ulong IDAllocator;

        public delegate void PlayDelegate(Play play);

        readonly PlayDelegate playSink;
        readonly Card deckCard;
        readonly HashSet<CardModifier> additionalModifiers;

        public FieldCard(PlayDelegate playSink, Card deckCard)
            : this(playSink, deckCard, null, deckCard.Upgraded)
        {
        }

        private FieldCard(PlayDelegate playSink, Card deckCard, HashSet<CardModifier>? additionalModifiers, bool upgraded)
        {
            this.playSink = playSink ?? throw new ArgumentNullException(nameof(playSink));
            this.deckCard = deckCard ?? throw new ArgumentNullException(nameof(deckCard));
            this.additionalModifiers = additionalModifiers != null
                ? new HashSet<CardModifier>(additionalModifiers)
                : new HashSet<CardModifier>();
            ID = Interlocked.Increment(ref IDAllocator);
            Upgraded = upgraded;
        }

        public ulong ID { get; init; }

        public ICardArchetype Archetype => deckCard.Archetype;

        public string InHandState => $"{State.CardInHandPrefix} {ToString()} ({ID})";

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
            var result = new FieldCard(playSink, deckCard, additionalModifiers, Upgraded);
            return result;
        }

        public bool EquivalentTo(FieldCard other)
        {
            // TODO
            return Archetype == other.Archetype
                && Upgraded == other.Upgraded;
        }

        public override string ToString() => Archetype.ToString(Upgraded);

        public IEnumerable<MountainGoap.Action> GenerateActions(IEnumerable<Enemy> potentialTargets)
        {
            var userSelectionPermutations = Archetype.SelectTargetPermutations(potentialTargets, Upgraded);
            foreach (var userSelectionRandomPermutations in userSelectionPermutations)
            {
                var cost = userSelectionRandomPermutations.Count;
                foreach (var targetList in userSelectionRandomPermutations)
                {
                    var playName = new StringBuilder("Play ");
                    playName.Append(ToString());
                    playName.Append(" (");
                    playName.Append(ID);
                    playName.Append(")");

                    if (targetList.Count > 0)
                    {
                        playName.Append(" against: ");
                        bool first = true;
                        foreach (var target in targetList)
                        {
                            if (first)
                                playName.Append(", ");
                            else
                                first = false;

                            playName.Append(target.ToString());
                        }
                    }

                    var playNameStr = playName.ToString();
                    var builder = new ActionBuilder(
                        () => playSink(
                            new Play
                            {
                                CardID = ID,
                                Name = playNameStr,
                                TargetIDs = targetList.Select(enemy => enemy.ID).ToList(),
                            }),
                        playName.ToString(),
                        cost);

                    builder.StaticPreconditions.Add(InHandState, true);

                    Archetype.BuildAction(targetList, builder, Upgraded);

                    if (targetList.Count > 0)
                        foreach (var target in targetList)
                            StatusRepository.Apply(status => status.OnActionTaken(builder, null, target));
                    else
                        StatusRepository.Apply(status => status.OnActionTaken(builder, null, null));

                    yield return builder.Build();
                }
            }
        }

    }
}

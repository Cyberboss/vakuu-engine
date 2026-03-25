using System.Collections.Generic;

using SlayTheSpire.Goap.Statuses;

namespace SlayTheSpire.Goap.Cards
{
    public abstract class Defend<TDefend> : CardArchetype<TDefend>
        where TDefend : Defend<TDefend>, new()
    {
        public override string Name => "Defend";

        public override CardType Type => CardType.Attack;

        public override bool EnemyTargeted => false;

        public override byte EnergyCost(bool upgraded) => 1;

        public IEnumerable<IStatus> InvokerStatuses(bool upgraded)
        {
            yield return new Block((short)(upgraded ? 8 : 5));
        }
    }
}

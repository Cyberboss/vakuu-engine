using System.Collections.Generic;
using System.Linq;

namespace SlayTheSpire2.Goap
{
    public interface ICardArchetype
    {
        string Name { get; }

        CardType Type { get; }
        CardPool Pool { get; }

        bool EnemyTargeted { get; }

        IEnumerable<CardModifier> Modifiers(bool upgraded) => Enumerable.Empty<CardModifier>();
        byte EnergyCost(bool upgraded);
        ushort Damage(bool upgraded) => 0;

        IEnumerable<IStatus> TargetStatuses(bool upgaded) => Enumerable.Empty<IStatus>();
        IEnumerable<IStatus> InvokerStatuses(bool upgaded) => Enumerable.Empty<IStatus>();
    }
}
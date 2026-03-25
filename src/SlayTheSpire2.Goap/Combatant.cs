using System;
using System.Collections.Generic;

namespace SlayTheSpire.Goap
{
    public abstract class Combatant
    {
        readonly List<IStatus> statuses;
        protected Combatant(
            IEnumerable<IStatus> statuses,
            Health health)
        {
            ArgumentNullException.ThrowIfNull(statuses);

            this.statuses = new List<IStatus>();
            foreach (var status in statuses)
            {
                this.ApplyStatus(status);
            }
        }

        public IReadOnlyList<IStatus> Statuses => statuses;
        public Health Health { get; private set; }

        public void ApplyStatus(IStatus status)
        {
            ArgumentNullException.ThrowIfNull(status);
            for (var i = 0; i < statuses.Count; ++i)
            {
                var existingStatus = statuses[i];
                var mergeResult = existingStatus.TryMergeInto(status);
                if (mergeResult.HasValue)
                {
                    if (!mergeResult.Value)
                        statuses.RemoveAt(i);
                    return;
                }
            }

            statuses.Add(status);
        }
    }
}

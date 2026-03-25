using System.Collections.Generic;

using MountainGoap;

namespace SlayTheSpire.Goap
{
    internal sealed class MaximizeDosh : ExtremeGoal
    {
        public MaximizeDosh(float weight)
            : base(
                  "Maximize Dosh",
                  weight,
                  new Dictionary<string, bool>
                  {
                      { State.Gold, true },
                  })
        {
        }
    }
}
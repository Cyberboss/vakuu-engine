using System.Collections.Generic;

using MountainGoap;

namespace SlayTheSpire2.Goap.Goals
{
    internal sealed class MaximizeDosh : ExtremeGoal
    {
        public MaximizeDosh(float weight)
            : base(
                  "Maximize Gold",
                  weight,
                  new Dictionary<string, bool>
                  {
                      { State.Gold, true },
                  })
        {
        }
    }
}

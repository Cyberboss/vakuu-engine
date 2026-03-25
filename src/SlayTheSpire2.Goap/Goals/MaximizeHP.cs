using System.Collections.Generic;

using MountainGoap;

namespace SlayTheSpire.Goap.Goals
{
    internal sealed class MaximizeHP : ExtremeGoal
    {
        public MaximizeHP(float weight)
            : base(
                  "Maximize HP",
                  weight,
                  new Dictionary<string, bool>
                  {
                      { State.CurrentHP, true },
                  })
        {
        }
    }
}

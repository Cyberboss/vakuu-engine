using System.Collections.Generic;

using MountainGoap;

namespace SlayTheSpire2.Goap.Goals
{
    internal sealed class DontLoseMaxHP : ExtremeGoal
    {
        public DontLoseMaxHP(float weight)
            : base(
                  "Don't Lose Max HP",
                  weight,
                  new Dictionary<string, bool>
                  {
                      { State.MaximumHP, true },
                  })
        {
        }
    }
}

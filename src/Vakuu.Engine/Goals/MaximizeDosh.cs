using System.Collections.Generic;

using MountainGoap;

namespace Vakuu.Engine.Goals
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

using System.Collections.Generic;

using MountainGoap;

namespace Vakuu.Engine.Goals
{
    internal sealed class MaintainPotions : ExtremeGoal
    {
        public MaintainPotions(float weight)
            : base(
                  "Maintain Potions",
                  weight,
                  new Dictionary<string, bool>
                  {
                      { State.PotionCount, false },
                  })
        {
        }
    }
}

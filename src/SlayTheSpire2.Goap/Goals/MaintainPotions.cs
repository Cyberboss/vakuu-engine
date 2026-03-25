using System.Collections.Generic;

using MountainGoap;

namespace SlayTheSpire2.Goap.Goals
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

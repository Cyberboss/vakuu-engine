using System.Collections.Generic;

using MountainGoap;

namespace SlayTheSpire2.Goap.Goals
{
    internal sealed class Survive : Goal
    {
        public Survive(float weight)
            : base(
                  "Survive",
                  weight,
                  new Dictionary<string, object?>
                  {
                      { State.EnemiesAlive, (byte)0 },
                  })
        {
        }
    }
}

using System.Collections.Generic;

using MountainGoap;

namespace SlayTheSpire.Goap.Goals
{
    internal sealed class WinEncounter : Goal
    {
        public WinEncounter(float weight)
            : base(
                  "Win Encounter",
                  weight,
                  new Dictionary<string, object?>
                  {
                      { State.EnemiesAlive, (byte)0 },
                  })
        {
        }
    }
}

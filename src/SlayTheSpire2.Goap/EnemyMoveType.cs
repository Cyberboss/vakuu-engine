using System;

namespace SlayTheSpire2.Goap
{
    [Flags]
    public enum EnemyMoveType
    {
        None,
        Attack = 1 << 0,
        Block = 1 << 1,
        Buff = 1 << 2,
        Escape = 1 << 3,
        Debuff = 1 << 4,
        GiveStatus = 1 << 5,
        Sleep = 1 << 6,
        Heal = 1 << 7,
    }
}

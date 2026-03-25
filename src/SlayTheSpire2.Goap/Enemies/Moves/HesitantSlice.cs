using System;

namespace SlayTheSpire2.Goap.Enemies.Moves
{
    internal sealed class HesitantSlice : IEnemyMove
    {
        public string Name => "Hesitant Slice";

        public EnemyMoveType Type => EnemyMoveType.Attack | EnemyMoveType.Block;

        public void Apply() => throw new NotImplementedException();
    }
}

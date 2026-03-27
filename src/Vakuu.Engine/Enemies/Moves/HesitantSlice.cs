using System;

namespace Vakuu.Engine.Enemies.Moves
{
    internal sealed class HesitantSlice : IEnemyMove
    {
        public string Name => "Hesitant Slice";

        public EnemyMoveType Type => EnemyMoveType.Attack | EnemyMoveType.Block;

        public void Apply() => throw new NotImplementedException();
    }
}

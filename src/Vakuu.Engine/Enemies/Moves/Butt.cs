using System;

namespace Vakuu.Engine.Enemies.Moves
{
    internal sealed class Butt : IEnemyMove
    {
        public string Name => "Butt";

        public EnemyMoveType Type => EnemyMoveType.Attack;

        public void Apply() => throw new NotImplementedException();
    }
}

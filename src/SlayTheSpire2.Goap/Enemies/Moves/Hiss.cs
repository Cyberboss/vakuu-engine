namespace SlayTheSpire2.Goap.Enemies.Moves
{
    internal sealed class Hiss : IEnemyMove
    {
        public string Name => "Hiss";

        public EnemyMoveType Type => EnemyMoveType.Buff;

        public void Apply() => throw new System.NotImplementedException();
    }
}

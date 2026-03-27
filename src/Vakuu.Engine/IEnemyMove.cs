namespace Vakuu.Engine
{
    public interface IEnemyMove
    {
        public string Name { get; }
        public EnemyMoveType Type { get; }

        void Apply();
    }
}

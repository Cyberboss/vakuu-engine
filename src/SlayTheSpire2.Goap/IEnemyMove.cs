namespace SlayTheSpire2.Goap
{
    public interface IEnemyMove
    {
        public string Name { get; }
        public EnemyMoveType Type { get; }

        void Apply();
    }
}

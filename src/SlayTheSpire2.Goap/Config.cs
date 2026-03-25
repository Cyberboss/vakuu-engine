namespace SlayTheSpire2.Goap
{
    public sealed class Config
    {
        public float Survive { get; init; } = 1.0f;
        public float DontOverheal { get; init; } = 0.9f;
        public float MaximizeHP { get; init; } = 0.85f;
        public float PreserveMaxHP { get; init; } = 0.8f;
        public float MaximizeDosh { get; init; } = 0.25f;
        public float MaintainPotions { get; init; } = 0.2f;
        public float Win { get; init; } = 0.1f;
    }
}

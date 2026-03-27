namespace Vakuu.Engine
{
    public sealed class Config
    {
        public float DontOverheal { get; init; } = 0.9f;
        public float MaximizeHP { get; init; } = 0.85f;
        public float PreserveMaxHP { get; init; } = 0.8f;
        public float MaximizeDosh { get; init; } = 0.25f;
        public float MaintainPotions { get; init; } = 0.2f;
        public float WinAndSurvive { get; init; } = 0.1f;
    }
}

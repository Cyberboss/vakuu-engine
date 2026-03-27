namespace Vakuu.Engine
{
    public interface IRelic : IStateMutator
    {
        void OnCombatEnd(ActionBuilder actionBuilder);
    }
}
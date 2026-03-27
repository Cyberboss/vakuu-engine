namespace Vakuu.Engine
{
    public interface IStateMutator
    {
        public string Name { get; }

        void OnTurnStart(ActionBuilder actionBuilder)
        {
        }

        void OnActionTaken(ActionBuilder actionBuilder, Combatant? source, Combatant? target)
        {
        }

        void OnTurnEnd(ActionBuilder actionBuilder)
        {
        }
    }
}
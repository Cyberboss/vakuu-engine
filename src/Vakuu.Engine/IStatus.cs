namespace Vakuu.Engine
{
    public interface IStatus : IStateMutator
    {
        public string StateName => State.StatusPrefix + Name;
    }
}
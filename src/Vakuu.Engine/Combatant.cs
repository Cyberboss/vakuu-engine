namespace Vakuu.Engine
{
    public abstract class Combatant
    {
        public abstract string HealthState { get; }
        public abstract string MaxHealthState { get; }

        public abstract string StatusState(IStatus status);
    }
}

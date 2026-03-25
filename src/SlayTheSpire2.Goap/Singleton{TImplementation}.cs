using System;

namespace SlayTheSpire2.Goap
{
    public abstract class Singleton<TImplementation>
        where TImplementation : Singleton<TImplementation>, new()
    {
        static readonly Lazy<TImplementation> Lazy = new Lazy<TImplementation>(() => new TImplementation());

        public static TImplementation Instance => Lazy.Value;
    }
}

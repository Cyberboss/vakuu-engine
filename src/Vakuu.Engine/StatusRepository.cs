using System;

using Vakuu.Engine.Statuses;

namespace Vakuu.Engine
{
    internal static class StatusRepository
    {
        public static Block Block { get; } = new Block();

        public static void Apply(Action<IStatus> applicator)
        {

        }
    }
}

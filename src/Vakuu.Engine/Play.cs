using System.Collections.Generic;

namespace Vakuu.Engine
{
    public sealed class Play
    {
        public required string Name { get; init; }
        public ulong? CardID { get; init; }
        public required IReadOnlyList<ulong> TargetIDs { get; init; }
    }
}

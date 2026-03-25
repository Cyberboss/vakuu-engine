using System;
using System.Collections.Generic;

using SlayTheSpire2.Goap.Enemies.Moves;

namespace SlayTheSpire2.Goap.Enemies
{
    internal sealed class Nibbit : IEnemyArchetype
    {
        public Nibbit(int patternIndex)
        {
            var moveset = new List<IEnemyMove>(3);
            var butt = new Butt();
            var hesitantSlice = new HesitantSlice();
            var hiss = new Hiss();
            switch (patternIndex)
            {
                case 0:
                    moveset.Add(butt);
                    moveset.Add(hesitantSlice);
                    moveset.Add(hiss);
                    break;
                case 1:
                    moveset.Add(hesitantSlice);
                    moveset.Add(hiss);
                    moveset.Add(butt);
                    break;
                case 2:
                    moveset.Add(hiss);
                    moveset.Add(butt);
                    moveset.Add(hesitantSlice);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(patternIndex), patternIndex, $"Must be 0, 1, or 2!");
            }

            Name = $"Nibbit (Pattern {patternIndex + 1})";
            Moveset = moveset;
        }

        public string Name { get; }

        public IReadOnlyList<IEnemyMove> Moveset { get; }

        public (ushort Low, ushort High) HPRange(Ascension ascension)
        {
            if (ascension.HasFlag(Ascension.DeadlyEnemies))
                return (44, 48);

            return (42, 46);
        }

    }
}

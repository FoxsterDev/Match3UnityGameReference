using System;

namespace Match3.GameCore
{
    [Serializable]
    public sealed class FinishLevelForTheLimitedMoves : ILevelGoal
    {
        public uint Moves;
    }
}

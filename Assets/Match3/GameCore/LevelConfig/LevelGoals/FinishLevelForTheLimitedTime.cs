using System;

namespace Match3.GameCore
{
    [Serializable]
    public sealed class FinishLevelForTheLimitedTime : ILevelGoal
    {
        public uint TimeInSeconds;
    }
}

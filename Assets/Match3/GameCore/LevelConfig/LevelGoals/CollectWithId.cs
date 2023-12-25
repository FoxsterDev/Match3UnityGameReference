using System;

namespace Match3.GameCore
{
    [Serializable]
    public sealed class CollectWithId : ILevelGoal
    {
        public uint Count;
        public uint Id;
    }
}

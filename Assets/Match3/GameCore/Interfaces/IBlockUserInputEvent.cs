using System;

namespace Match3.GameCore
{
    public interface IBlockUserInputEvent : IDisposable
    {
        event Action<BlockMoveDirection> OnMove;
    }
}

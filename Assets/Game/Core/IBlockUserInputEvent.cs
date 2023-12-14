using System;

namespace Match3.GameCore
{
    public interface IBlockUserInputEvent
    {
        event Action<BlockMoveDirection> OnMove;
    }
}

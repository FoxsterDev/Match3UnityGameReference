using System;
using UnityEngine.Events;

namespace Match3.GameCore
{
    public interface IBlockUserInputEvent : IDisposable
    {
        event UnityAction<BlockMoveDirection> OnMove;
    }
}

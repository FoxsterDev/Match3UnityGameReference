using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Match3.GameCore
{
    public class BlockUserEventTrigger : EventTrigger, IBlockUserInputEvent
    {
        public event Action<BlockMoveDirection> OnMove
        {
            add => _onMove += value;
            remove => _onMove -= value;
        }

        public void Dispose()
        {
            if (_onMove != null) //trash
            {
                foreach (var del in _onMove.GetInvocationList())
                {
                    _onMove -= (Action<BlockMoveDirection>) del;
                }

                var lentgh = _onMove?.GetInvocationList().Length ?? 0;
                Debug.Log(name + ",InvocationList " + lentgh);
            }
        }

        event Action<BlockMoveDirection> _onMove;

        public override void OnBeginDrag(PointerEventData eventData)
        {
            var delta = eventData.delta;
            //to test
            var direction = CalculateBlockDraggingDirection(delta);

            Debug.Log("Direction tracked =" + ", " + direction);
            _onMove?.Invoke(direction);
        }

        BlockMoveDirection CalculateBlockDraggingDirection(Vector2 delta)
        {
            var direction = BlockMoveDirection.NotDetected;
            const float sensitivityLimit = 3.0f;
            if (delta.x < -sensitivityLimit)
            {
                direction = BlockMoveDirection.Left;
            }
            else if (delta.x > sensitivityLimit)
            {
                direction = BlockMoveDirection.Right;
            }
            else if (delta.y > sensitivityLimit)
            {
                direction = BlockMoveDirection.Up;
            }
            else if (delta.y < -sensitivityLimit)
            {
                direction = BlockMoveDirection.Down;
            }

            return direction;
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Match3.GameCore
{
    public class BlockUserEventTrigger : EventTrigger, IBlockUserInputEvent
    {
        event Action<BlockMoveDirection> _onMove;
        public event Action<BlockMoveDirection> OnMove
        {
            add => _onMove += value;
            remove { _onMove -= value; }
        }

        void OnDisable()
        {
            if (_onMove != null)//trash
            {
                var count = _onMove.GetInvocationList().Length;
                if (count > 0 && Application.isPlaying)
                {
                    Debug.LogWarning(name +" has unsubscribed events ");
                }
            }
        }

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

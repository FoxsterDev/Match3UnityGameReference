using UnityEngine;
using UnityEngine.EventSystems;

namespace Match3.GameCore
{
    public class BlockEventTrigger : EventTrigger
    {
        public override void OnBeginDrag(PointerEventData eventData)
        {
            var delta = eventData.delta;
            //to test
            var direction = CalculateBlockDraggingDirection(delta);

            Debug.Log("Direction tracked =" + ", " + direction);
        }

        BlockDraggingDirection CalculateBlockDraggingDirection(Vector2 delta)
        {
            var direction = BlockDraggingDirection.NotDetected;
            const float sensitivityLimit = 3.0f;
            if (delta.x < -sensitivityLimit)
            {
                direction = BlockDraggingDirection.Left;
            }
            else if (delta.x > sensitivityLimit)
            {
                direction = BlockDraggingDirection.Right;
            }
            else if (delta.y > sensitivityLimit)
            {
                direction = BlockDraggingDirection.Up;
            }
            else if (delta.y < -sensitivityLimit)
            {
                direction = BlockDraggingDirection.Down;
            }

            return direction;
        }
    }
}

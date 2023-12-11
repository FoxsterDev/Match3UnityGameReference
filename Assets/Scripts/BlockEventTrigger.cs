using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BlockDraggingDirection
{
    NotDetected = -1,
    Left = 0,
    Right = 1,
    Up = 2,
    Down = 3
}
public class BlockEventTrigger : EventTrigger
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        var delta = eventData.delta;
        //to test
        var direction = CalculateBlockDraggingDirection(delta);

        Debug.Log("Direction tracked ="+ ", "+ direction);
    }

    BlockDraggingDirection CalculateBlockDraggingDirection(Vector2 delta)
    {
        var direction = BlockDraggingDirection.NotDetected;
        const float sensitivityLimit = 3.0f;
        if (delta.x < -sensitivityLimit) { direction = BlockDraggingDirection.Left;} else
        if (delta.x > sensitivityLimit) {  direction = BlockDraggingDirection.Right;} else
        if (delta.y > sensitivityLimit) { direction = BlockDraggingDirection.Up;} else
        if (delta.y < -sensitivityLimit) direction = BlockDraggingDirection.Down;
        return direction;
    }
}

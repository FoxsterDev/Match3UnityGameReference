using System;
using UnityEngine;

namespace Match3.GameCore
{
    public class GameBoardController : IDisposable
    {
        readonly BlockEntity[,] _board;
        readonly uint _columnCount;
        readonly uint _rowCount;

        public GameBoardController(uint rowCount, uint columnCount)
        {
            _rowCount = rowCount;
            _columnCount = columnCount;

            _board = new BlockEntity[_rowCount, _columnCount];
        }

        public void Dispose()
        {
        }

        public void AddBlock(int index,
                             int rowIndex,
                             int columnIndex,
                             IBlockView blockView,
                             IBlockUserInputEvent blockUserInput)
        {
            var block = new BlockEntity(index, rowIndex, columnIndex, blockView, blockUserInput);
            _board[block.RowIndex, block.ColumnIndex] = block;

            //  cDisplayClass50.block.UserInput.OnMove += new Action<BlockMoveDirection>((object) cDisplayClass50, __methodptr(<AddBlock>b__0));
            block.UserInput.OnMove += delegate(BlockMoveDirection direction) { OnMoveUserInputEvent(block, direction); };
        }

        void OnMoveUserInputEvent(BlockEntity block, BlockMoveDirection direction)
        {
            var isMoveAllowed = IsMoveAllowed(_rowCount, _columnCount, block, direction);

            Debug.Log(nameof(OnMoveUserInputEvent) + " ,direction=" + direction + " for " + block+" , "+nameof(isMoveAllowed) +"=>"+isMoveAllowed);
            if (isMoveAllowed)
            {
                //check pattern: 3 and more in horizontal or vertical
                //play animation depends on pattern
                //if success animate shifts
                //create new elements
            }

        }

        //testable method
        bool IsMoveAllowed(uint rowCount,
                           uint columnCount,
                           BlockEntity block,
                           BlockMoveDirection direction)
        {
            var rowIndexTemp = block.RowIndex;
            var columnIndexTemp = block.ColumnIndex;

            switch (direction)
            {
                case BlockMoveDirection.NotDetected:
                {
                    return false;
                }
                case BlockMoveDirection.Down:
                {
                    rowIndexTemp += 1;
                    break;
                }
                case BlockMoveDirection.Up:
                {
                    rowIndexTemp -= 1;
                    break;
                }
                case BlockMoveDirection.Left:
                {
                    columnIndexTemp -= 1;
                    break;
                }
                case BlockMoveDirection.Right:
                {
                    columnIndexTemp += 1;
                    break;
                }
            }

            if (columnIndexTemp < 0 || rowIndexTemp < 0 || columnIndexTemp >= columnCount || rowIndexTemp >= rowCount)
            {
                return false;
            }

            return true;
        }
    }
}

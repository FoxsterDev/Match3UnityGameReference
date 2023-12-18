using System;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.GameCore
{
    public interface IAnimationsPlayer
    {
        void AnimateMove(BlockEntity current, BlockEntity target);
    }

    public class GameBoardAnimationsPlayer : IAnimationsPlayer
    {
        public void AnimateMove(BlockEntity current, BlockEntity target)
        {
        }
    }

    public class GameBoardController : IDisposable
    {
        readonly BlockEntity[,] _board;
        readonly uint _columnCount;
        readonly ICompacting _compacting;
        readonly IMatchPattern _matchPattern;
        readonly uint _rowCount;

        //rethink
        readonly ScoreController _scoreController;

        Pool<IBlockView, int> _pool = new();

        public GameBoardController(GameLevelConfig levelConfig,
                                   uint rowCount,
                                   uint columnCount)
        {
            _rowCount = rowCount;
            _columnCount = columnCount;

            _board = new BlockEntity[_rowCount, _columnCount];
            _matchPattern = new Match3AndMoreInHorizontalOrVerticalPattern();
            _scoreController = new ScoreController(levelConfig);
            _compacting = new GameBoardCompacting();
        }

        public void Dispose()
        {
        }

        public void AddBlock(
            int rowIndex,
            int columnIndex,
            IBlockView blockView,
            IBlockUserInputEvent blockUserInput)
        {
            var block = new BlockEntity(rowIndex, columnIndex, blockView, blockUserInput);
            _board[rowIndex, columnIndex] = block;

            //cDisplayClass50.currentBlock.UserInput.OnMove += new Action<BlockMoveDirection>((object) cDisplayClass50, __methodptr(<AddBlock>b__0));
            //https://www.c-sharpcorner.com/article/c-sharp-local-function-vs-delegates/
            void MoveCallback(BlockMoveDirection direction)
            {
                OnMoveUserInputEvent(block, direction);
            }

            block.UserInput.OnMove += MoveCallback;
        }

        void DestroyBlock(BlockEntity entity)
        {
            //_pool.Release(entity.View);
            //entity.UserInput.OnMove -= onMoveCallback;
            entity.Destroy();
        }

        public void AnimateCompacting(List<(int startRow, int startColumn, int targetRow, int targetColumn)> shifts)
        {
            //  //async animate this
            foreach (var shift in shifts)
            {
                var currentBlock = _board[shift.startRow, shift.startColumn];
                var emptyBlock = _board[shift.targetRow, shift.targetColumn];

                _board[shift.targetRow, shift.targetColumn] = currentBlock;
                _board[shift.startRow, shift.startColumn] = emptyBlock;

                currentBlock.SwapWith(emptyBlock);
            }
        }

        public void AnimateMatch(List<(int row, int column, uint id)> match)
        {
            var blocks = new List<BlockEntity>(match.Count);
            foreach (var block in match)
            {
                var entity = _board[block.row, block.column];
                blocks.Add(entity);
            }

            foreach (var block in blocks)
            {
                DestroyBlock(block);
            }
        }
/*
        void Compacting(BlockEntity[,] board)
        {
            var rowsCount = board.GetLength(0);
            var columnsCount = board.GetLength(1);

            for (var col = columnsCount - 1; col >= 0; col--)
            {
                var startEmptyRow = -1;
                for (var row = rowsCount - 1; row >= 0; row--)
                {
                    if (board[row, col].IsEmpty)
                    {
                        if (startEmptyRow < 0)
                        {
                            startEmptyRow = row;
                        }
                    }
                    else if (startEmptyRow > -1)
                    {
                        var currentBlock = board[row, col];
                        var emptyBlock = board[startEmptyRow, col];

                        _board[startEmptyRow, col] = currentBlock;
                        _board[row, col] = emptyBlock;

                        //async animate this
                        currentBlock.SwapWith(emptyBlock);

                        startEmptyRow = row;
                    }
                }
            }
        }
*/
        void OnMoveUserInputEvent(BlockEntity currentBlock, BlockMoveDirection direction)
        {
            var isMoveAllowed = IsMoveAllowed(
                _rowCount,
                _columnCount, currentBlock, direction,
                out var rowIndexNew, out var columnIndexNew);

            Debug.Log(
                nameof(OnMoveUserInputEvent) + " ,direction=" + direction + " for " + currentBlock + " , " + nameof(isMoveAllowed) + "=>" + isMoveAllowed);
            if (isMoveAllowed)
            {
                var targetBlock = _board[rowIndexNew, columnIndexNew];
                //update board 
                _board[rowIndexNew, columnIndexNew] = currentBlock;
                _board[currentBlock.RowIndex, currentBlock.ColumnIndex] = targetBlock;

                //async animate this
                currentBlock.SwapWith(targetBlock);

                var hasMatch = _matchPattern.IsMatched(
                    _board,
                    out var matchesInTheRow,
                    out var matchesInTheColumn,
                    BlockEntity.EMPTY_ID);

                if (hasMatch)
                {
                    //animate matches
                    AnimateMatches(matchesInTheRow, matchesInTheColumn);
                    //calculate score
                    _scoreController.CalculateScoreForTheMatches(matchesInTheRow, matchesInTheColumn);

                    //animate compacting
                    _compacting.Compact(_board, out var shifts);
                    AnimateCompacting(shifts);

                    //create new blocks
                }
                else
                {
                    Debug.Log("No pattern found");
                    //animate compacting
                    _compacting.Compact(_board, out var shifts);
                    AnimateCompacting(shifts);
                    //swap back blocks as candy crash
                }
                //check pattern

                //build animations

                //animate the change 

                //check pattern: 3 and more in horizontal or vertical
                //play animation depends on pattern
                //if success animate shifts
                //create new elements
            }
        }

        void AnimateMatches(List<List<(int row, int column, uint id)>> matchesInTheRow, List<List<(int row, int column, uint id)>> matchesInTheColumn)
        {
            foreach (var match in matchesInTheRow)
            {
                AnimateMatch(match); //async animation
            }

            foreach (var match in matchesInTheColumn)
            {
                AnimateMatch(match); //async animation
            }
        }

        //testable method
        bool IsMoveAllowed(uint rowCount,
                           uint columnCount,
                           BlockEntity block,
                           BlockMoveDirection direction,
                           out int rowIndexTemp,
                           out int columnIndexTemp)
        {
            rowIndexTemp = block.RowIndex;
            columnIndexTemp = block.ColumnIndex;

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

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

    public partial class GameBoardController : IDisposable
    {
        readonly BlockEntity[,] _board;
        readonly uint _columnCount;
        readonly uint _rowCount;
        readonly IMatchPattern _matchPattern;
        //rethink
        readonly ScoreController _scoreController;
        
        public GameBoardController(GameLevelConfig levelConfig, uint rowCount, uint columnCount)
        {
            _rowCount = rowCount;
            _columnCount = columnCount;

            _board = new BlockEntity[_rowCount, _columnCount];
            _matchPattern = new Match3AndMoreInHorizontalOrVerticalPattern();
            _scoreController = new ScoreController(levelConfig);

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

            //  cDisplayClass50.block.UserInput.OnMove += new Action<BlockMoveDirection>((object) cDisplayClass50, __methodptr(<AddBlock>b__0));
            Action<BlockMoveDirection> onMoveCallback = delegate(BlockMoveDirection direction)
            {
                OnMoveUserInputEvent(block, direction);
            };
            block.UserInput.OnMove += onMoveCallback;
        }

        public void  DestroyBlock(BlockEntity entity)
        {
            //_pool.Release(entity.View);
            _board[entity.RowIndex, entity.ColumnIndex] = null;
            var gameObject = ((MonoBehaviour) entity.View).gameObject;
           // entity.UserInput.OnMove -= onMoveCallback;
           UnityEngine.Object.Destroy(gameObject);
           entity.UserInput.Dispose();
           entity.View.Dispose();
        }

        public void  AnimateMatch(List<(int row, int column)> match)
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

        Pool<IBlockView, int> _pool = new Pool<IBlockView, int>();


        void Compacting(BlockEntity[,] board)
        {
            var rowsCount = board.GetLength(0);
            var columnsCount = board.GetLength(1);

            //var matrix = new uint[rowsCount, columnsCount];
            for (var col = columnsCount - 1; col >= 0; col--)
            {
                for (var row = rowsCount - 1; row >= 0; row--)
                {
                    //matrix[row, col] = board[row, col].ID;
                }
                
            }
           
        }

        void OnMoveUserInputEvent(BlockEntity block, BlockMoveDirection direction)
        {
            var isMoveAllowed = IsMoveAllowed(_rowCount, 
                                              _columnCount, block, direction, 
                                              out var rowIndexNew, out var columnIndexNew);

            Debug.Log(nameof(OnMoveUserInputEvent) + " ,direction=" + direction + " for " + block+" , "+nameof(isMoveAllowed) +"=>"+isMoveAllowed);
            if (isMoveAllowed) //rowIndexTemp , columnIndexTemp is valid indexes for a block
            {
                var currentBlock = block; // from  block positions => new column
                var targetBlock = _board[rowIndexNew, columnIndexNew];

                //update board 
                _board[rowIndexNew, columnIndexNew] = currentBlock;
                _board[currentBlock.RowIndex, currentBlock.ColumnIndex] = targetBlock;
                //update block entity 
                //async animate this
                currentBlock.SwapWith(targetBlock);


                var isPatternFound = _matchPattern.IsMatched(_board, out var matchesInTheRow, out var matchesInTheColumn);
                if (isPatternFound)
                {
                   _scoreController.CalculateScoreForTheMatches(matchesInTheRow, matchesInTheColumn);
                   //async animate it 
                   foreach (var match in matchesInTheRow)
                   {
                       AnimateMatch(match); //async animation
                   }
                   foreach (var match in matchesInTheColumn)
                   {
                       AnimateMatch(match); //async animation
                   }
                   //shift block in the board: compacting
                   
                   //create new blocks
                }
                else
                {
                    Debug.Log("No pattern found");
                    //swap back blocks
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

       
        //testable method
        bool IsMoveAllowed(uint rowCount,
                           uint columnCount,
                           BlockEntity block,
                           BlockMoveDirection direction, 
                           out int rowIndexTemp,  
                           out int columnIndexTemp )
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

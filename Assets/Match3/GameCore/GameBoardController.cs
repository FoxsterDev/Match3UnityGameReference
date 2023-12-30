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
        readonly IBlocksGenerator _randomBlocksGenerator;
        readonly BlockEntity[,] _board;

        readonly Transform _boardTransformParent;
        readonly uint _columnCount;
        readonly ICompacting _compacting;
        readonly GameLevelConfig _levelConfig;
        readonly IMatchPattern _matchPattern;
        readonly IPossibleMatchPattern _possibleMatchPattern;

        readonly uint _rowCount;

        //rethink
        readonly ScoreController _scoreController;

        Pool<IBlockView, int> _pool = new();

        public GameBoardController(GameLevelConfig levelConfig,
                                   uint rowCount,
                                   uint columnCount,
                                   Transform boardTransformParent)
        {
            _levelConfig = levelConfig;
            _rowCount = rowCount;
            _columnCount = columnCount;
            _boardTransformParent = boardTransformParent;
            _board = new BlockEntity[_rowCount, _columnCount];
            _matchPattern = new MatchSomeCountInHorizontalOrVerticalPattern();
            _scoreController = new ScoreController(levelConfig);
            _compacting = new GameBoardCompacting();
            _randomBlocksGenerator = new GameBoardBlocksGenerator(levelConfig);
            _possibleMatchPattern = new PossibleMatch3PatternInHorizontalOrVerticalForTheOneMove();
        }

        public void Dispose()
        {
        }

        GameObject GetBlockPrefabById(uint id)
        {
            var blockView = _levelConfig.AllowedBlocks.Find(b => ((IBlockView) b).ID == id);
            if (blockView != null)
            {
                return blockView.gameObject;
            }
            else
            {
                return null;
            }
        }

        public void CreateBlock(int rowIndex,
                                int columnIndex,
                                GameObject prefab,
                                Vector3 position)
        {
            //pool
            var blockGameObjectInstance = UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity, _boardTransformParent);
            var blockUserInput = blockGameObjectInstance.GetComponent<IBlockUserInputEvent>();
            var blockView = blockGameObjectInstance.GetComponent<IBlockView>();

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

        void AnimateNewBlocks(List<(int row, int column, uint id)> blocks)
        {
            Debug.Log(nameof(AnimateNewBlocks) + string.Join(",", blocks));

            for (var index = 0; index < blocks.Count; index++)
            {
                var block = blocks[index];
                var prefab = GetBlockPrefabById(block.id);
                var entry = _board[block.row, block.column];
                CreateBlock(block.row, block.column, prefab, entry.Position);
            }
        }

        void AnimateCompacting(List<(int startRow, int startColumn, int targetRow, int targetColumn)> shifts)
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

        void AnimateMatch(List<(int row, int column, uint id)> match)
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

                Repeat:
                var hasMatch = _matchPattern.IsMatched(
                    _board.ConvertToIntMatrix(),
                    out var matchesInTheRow,
                    out var matchesInTheColumn,
                    BlockEntity.EMPTY_ID);

                if (hasMatch)
                {
                    AnimateMatches(matchesInTheRow, matchesInTheColumn);
                    _scoreController.CalculateScoreForTheMatches(matchesInTheRow, matchesInTheColumn);

                    _compacting.Compact(_board.ConvertToIntMatrix(), out var shifts, out var outBoard1);
                    AnimateCompacting(shifts);

                    var tryCount = 5;
                    var isPossibleMatches = false;
                    List<(int row, int column, uint id)> newBlocks;
                    do
                    {
                        _randomBlocksGenerator.Generate(_board.ConvertToIntMatrix(), out newBlocks, out var outBoard2);
                        isPossibleMatches = _possibleMatchPattern.IsPossibleMatched(outBoard2, out var result, 0);
                    }
                    while (!isPossibleMatches && tryCount-- > 0);

                    Debug.Log("IsPossibleMatched: " + isPossibleMatches +(5-tryCount));
                    AnimateNewBlocks(newBlocks);

                    goto Repeat;
                }
                else
                {
                    Debug.Log("No pattern found");
                    //swap back blocks as candy crash

                    //targetBlock.SwapWith(currentBlock);

                    //_compacting.Compact(_board.ConvertToIntMatrix(), out var shifts, out var outBoard3);
                    //AnimateCompacting(shifts);
                }
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

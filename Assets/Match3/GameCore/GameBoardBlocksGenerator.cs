using System.Collections.Generic;
using UnityEngine;

namespace Match3.GameCore
{
    /// <summary>
    /// Default generator is just random
    /// </summary>
    public class GameBoardBlocksGenerator : IBlocksGenerator
    {
        readonly uint _maxBlockId;
        readonly uint _minBlockId;

        public GameBoardBlocksGenerator(GameLevelConfig levelConfig)
        {
            _minBlockId = levelConfig.MinBlockId;
            _maxBlockId = levelConfig.MaxBlockId;
        }

        public GameBoardBlocksGenerator(uint minBlockId, uint maxBlockId)
        {
            _minBlockId = minBlockId;
            _maxBlockId = maxBlockId;
        }

        public void Generate(uint[,] board,
                             out List<(int row, int column, uint id)> blocks,
                             out uint[,] outBoard)
        {
            blocks = new List<(int row, int column, uint id)>(1);

            var rowsCount = board.GetLength(0);
            var columnsCount = board.GetLength(1);

            for (var col = columnsCount - 1; col >= 0; col--)
            {
                for (var row = rowsCount - 1; row >= 0; row--)
                {
                    if (board[row, col] == BlockEntity.EMPTY_ID)
                    {
                        var blockId = GenerateNewBlockId();
                        blocks.Add((row, col, blockId));
                        board[row, col] = blockId;
                    }
                }
            }

            outBoard = board;
        }

        uint GenerateNewBlockId()
        {
            return (uint) Random.Range(_minBlockId, _maxBlockId + 1);
        }
    }
}

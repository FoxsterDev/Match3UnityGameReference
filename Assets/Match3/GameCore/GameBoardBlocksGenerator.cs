using System;
using System.Collections.Generic;

namespace Match3.GameCore
{
    /// <summary>
    /// Default generator is just random
    /// </summary>
    public class GameBoardBlocksGenerator : IBlocksGenerator
    {
        readonly uint _minBlockId;
        readonly uint _maxBlockId;
    
        public GameBoardBlocksGenerator(GameLevelConfig levelConfig)
        {
            _minBlockId = levelConfig.MinBlockId;
            _maxBlockId = levelConfig.MaxBlockId;
        }

        public GameBoardBlocksGenerator(uint minBlockId , uint maxBlockId)
        {
            _minBlockId = minBlockId;
            _maxBlockId = maxBlockId;
        }

        uint GenerateNewBlockId()
        {
            return (uint)UnityEngine.Random.Range(_minBlockId, _maxBlockId + 1);
        }

        public void Generate(uint[,] board, out List<(int row, int column, uint id)> blocks)
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
                    }
                }
            }
        }

        public void Generate(BlockEntity[,] board, out List<(int row, int column, uint id)> blocks)
        {
           Generate(board.ConvertBoardToIntMatrix(), out blocks);
        }
    }
}

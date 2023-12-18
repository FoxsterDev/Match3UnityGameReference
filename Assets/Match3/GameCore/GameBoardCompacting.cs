using System;
using System.Collections.Generic;

namespace Match3.GameCore
{
    public class GameBoardCompacting : ICompacting
    {
        public void Compact(uint[,] board, out List<(int startRow, int startColumn, int targetRow, int targetColumn)> acts, out uint[,] outBoard)
        {
            acts = new List<(int startRow, int startColumn, int targetRow, int targetColumn)>(1);
            var rowsCount = board.GetLength(0);
            var columnsCount = board.GetLength(1);

            for (var col = columnsCount - 1; col >= 0; col--)
            {
                var startEmptyRow = -1;
                for (var row = rowsCount - 1; row >= 0; row--)
                {
                    if (board[row, col] == 0)
                    {
                        if (startEmptyRow < 0)
                        {
                            startEmptyRow = row;
                        }
                    }
                    else if(startEmptyRow > -1)
                    {
                        var currentBlock = board[row, col];
                        var emptyBlock = board[startEmptyRow, col];

                        board[startEmptyRow, col] = currentBlock;
                        board[row, col] = emptyBlock;

                        acts.Add((row, col, startEmptyRow, col));

                        row = startEmptyRow;
                        startEmptyRow = -1;
                    }
                }
            }

            outBoard = board;
        }

        public void Compact(BlockEntity[,] board, out List<(int startRow, int startColumn, int targetRow, int targetColumn)> acts)
        {
            Compact(board.ConvertBoardToIntMatrix(), out acts, out var outBoard);
        }
    }
}

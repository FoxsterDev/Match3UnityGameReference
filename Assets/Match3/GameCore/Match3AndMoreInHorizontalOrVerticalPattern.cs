using System;
using System.Collections.Generic;

namespace Match3.GameCore
{
    public class Match3AndMoreInHorizontalOrVerticalPattern : IMatchPattern
    {
        /// <summary>
        /// it is better for testing resons
        /// </summary>
        /// <param name="board"></param>
        /// <returns>converted matrix with block id</returns>
        uint[,] ConvertBoardToIntMatrix(BlockEntity[,] board)
        {
            var rowsCount = board.GetLength(0);
            var columnsCount = board.GetLength(1);

            var matrix = new uint[rowsCount, columnsCount];
            for (var row = 0; row < rowsCount; row++)
            {
                for (var col = 0; col < columnsCount; col++)
                {
                    matrix[row, col] = board[row, col].ID;
                }
            }

            return matrix;
        }
        /// <summary>
        ///  0, 1, 0, 2
        ///  0, 0, 2, 3
        ///  0, 1, 1, 4
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsMatched(BlockEntity[,] board, 
                              out List<List<(int row, int column)>> matchesInTheRow,
                              out List<List<(int row, int column)>> matchesInTheColumn)
        {
            return IsMatched(ConvertBoardToIntMatrix(board), 
                             out  matchesInTheRow,
                             out  matchesInTheColumn );
        }

        public bool IsMatched(uint[,] board)
        {
            return IsMatched(
                board,
                out var matchesInTheRow,
                out var matchesInTheColumn);
        }

        public bool IsMatched(uint[,] board, 
                              out List<List<(int row, int column)>> matchesInTheRow,
                              out List<List<(int row, int column)>> matchesInTheColumn )
        {
            var rowsCount = board.GetLength(0);
            var columnsCount = board.GetLength(1);

            var isMatchedInTheRow = HasMatchesInTheRow(board, rowsCount, columnsCount, out  matchesInTheRow);
            var isMatchedInTheColumn = HasMatchesInTheColumn(board, rowsCount, columnsCount, out  matchesInTheColumn);

            return isMatchedInTheRow || isMatchedInTheColumn;
        }
        bool HasMatchesInTheColumn(uint[,] board,
                                int rowsCount,
                                int columnsCount, 
                                out List<List<(int row, int column)>> matches)
        {
            matches = new List<List<(int row, int column)>>(1);

            for (var col = 0; col < columnsCount; col++)
            {
                var startId = board[0, col];
                var matchCount = 1;
                var matchList = new List<(int row, int column)>(3) { (0, col) };

                for (var row = 1; row < rowsCount; row++)
                {
                    var id = board[row, col];
                    if (startId == id)
                    {
                        matchCount += 1;
                        matchList.Add(new(row, col));
                    }
                    else
                    {
                        if (matchCount >= 3) // in the same row but different id
                        {
                            //save it
                            matches.Add(matchList);
                        }

                        startId = id;
                        matchCount = 1;
                        matchList = new List<(int row, int column)>(3) { (row, col) };
                    }
                }

                if (matchCount >= 3) //has match
                {
                    matches.Add(matchList);
                }
            }

            return matches.Count > 0;
        }
         bool HasMatchesInTheRow(uint[,] board,
                                      int rowsCount,
                                      int columnsCount, 
                                      out List<List<(int row, int column)>> matches)
        {
            matches = new List<List<(int row, int column)>>(1);

            for (var row = 0; row < rowsCount; row++)
            {
                var startId = board[row, 0];
                var matchCount = 1;
                var matchList = new List<(int row, int column)>(3) { new(row, 0) };
              
                for (var col = 1; col < columnsCount; col++)
                {
                    var id = board[row, col];
                    if (startId == id)
                    {
                        matchCount += 1;
                        matchList.Add(new(row, col));
                    }
                    else
                    {
                        if (matchCount >= 3) // in the same row but different id
                        {
                            //save it
                            matches.Add(matchList);
                        }

                        startId = id;
                        matchCount = 1;
                        matchList = new List<(int row, int column)>(3){ new(row, col) };
                    }
                }

                if (matchCount >= 3) //has match
                {
                    matches.Add(matchList);
                }
            }

            return matches.Count > 0;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace Match3.GameCore
{
    public class Match3AndMoreInHorizontalOrVerticalPattern : IMatchPattern
    {
        /// <summary>
        ///  0, 1, 0, 2
        ///  0, 0, 2, 3
        ///  0, 1, 1, 4
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsMatched(BlockEntity[,] board, 
                              out List<List<(int row, int column, uint id)>> matchesInTheRow,
                              out List<List<(int row, int column, uint id)>> matchesInTheColumn, 
                              params uint[] skipID)
        {
            return IsMatched(board.ConvertBoardToIntMatrix(), 
                             out  matchesInTheRow,
                             out  matchesInTheColumn, skipID );
        }

        public bool IsMatched(uint[,] board)
        {
            return IsMatched(
                board,
                out var matchesInTheRow,
                out var matchesInTheColumn);
        }

        public bool IsMatched(uint[,] board, 
                              out List<List<(int row, int column, uint id)>> matchesInTheRow,
                              out List<List<(int row, int column, uint id)>> matchesInTheColumn, 
                              params uint[] skipID)
        {
            var rowsCount = board.GetLength(0);
            var columnsCount = board.GetLength(1);

            var isMatchedInTheRow = HasMatchesInTheRow(board, rowsCount, columnsCount, out  matchesInTheRow);
            var isMatchedInTheColumn = HasMatchesInTheColumn(board, rowsCount, columnsCount, out  matchesInTheColumn);

            if (isMatchedInTheRow)
            {
                matchesInTheRow = matchesInTheRow.Where(m => m[0].id != 0).ToList();
                isMatchedInTheRow = matchesInTheRow.Count > 0;
            }

            if (isMatchedInTheColumn)
            {
                matchesInTheColumn = matchesInTheColumn.Where(m => m[0].id != 0).ToList();
                isMatchedInTheColumn = matchesInTheColumn.Count > 0;
            }
            return isMatchedInTheRow || isMatchedInTheColumn;
        }

        bool HasMatchesInTheColumn(uint[,] board,
                                int rowsCount,
                                int columnsCount, 
                                out List<List<(int row, int column, uint id)>> matches)
        {
            matches = new List<List<(int row, int column, uint id)>>(1);

            for (var col = 0; col < columnsCount; col++)
            {
                var startId = board[0, col];
                var matchCount = 1;
                var matchList = new List<(int row, int column, uint id)>(3) { (0, col, startId) };

                for (var row = 1; row < rowsCount; row++)
                {
                    var id = board[row, col];

                    if (startId == id)
                    {
                        matchCount += 1;
                        matchList.Add(new(row, col, id));
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
                        matchList = new List<(int row, int column, uint id)>(3) { (row, col, id) };
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
                                      out List<List<(int row, int column, uint id)>> matches)
        {
            matches = new List<List<(int row, int column, uint id)>>(1);

            for (var row = 0; row < rowsCount; row++)
            {
                var startId = board[row, 0];
                var matchCount = 1;
                var matchList = new List<(int row, int column, uint id)>(3) { new(row, 0, startId) };

                for (var col = 1; col < columnsCount; col++)
                {
                    var id = board[row, col];
                    if (startId == id)
                    {
                        matchCount += 1;
                        matchList.Add(new(row, col, id));
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
                        matchList = new List<(int row, int column, uint id)>(3){ new(row, col, id) };
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

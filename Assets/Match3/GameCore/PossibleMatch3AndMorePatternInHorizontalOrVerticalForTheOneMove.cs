using System;
using System.Collections.Generic;

namespace Match3.GameCore
{
    public class PossibleMatch3AndMorePatternInHorizontalOrVerticalForTheOneMove : IPossibleMatchPattern
    {
        bool IPossibleMatchPattern.IsPossibleMatched(uint[,] board,
                                                     out List<List<(int row, int column, uint id)>> possibleMatches,
                                                     params uint[] skipID)
        {
            var rowsCount = board.GetLength(0);
            var columnsCount = board.GetLength(1);

            var isMatchedInTheRow = HasMatchesInTheRow(board, rowsCount, columnsCount, out possibleMatches);
            var isMatchedInTheColumn = HasMatchesInTheColumn(board, rowsCount, columnsCount, out possibleMatches);

            if (isMatchedInTheRow)
            {
                //matchesInTheRow = matchesInTheRow.Where(m => m[0].id != 0).ToList();
                //isMatchedInTheRow = matchesInTheRow.Count > 0;
            }

            if (isMatchedInTheColumn)
            {
                //matchesInTheColumn = matchesInTheColumn.Where(m => m[0].id != 0).ToList();
                //isMatchedInTheColumn = matchesInTheColumn.Count > 0;
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
                        matchList.Add(new ValueTuple<int, int, uint>(row, col, id));
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
                        matchList.Add(new ValueTuple<int, int, uint>(row, col, id));
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
                        matchList = new List<(int row, int column, uint id)>(3) { new(row, col, id) };
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

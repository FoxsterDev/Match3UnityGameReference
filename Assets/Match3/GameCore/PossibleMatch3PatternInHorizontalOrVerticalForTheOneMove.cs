using System;
using System.Collections.Generic;

namespace Match3.GameCore
{
    public class PossibleMatch3PatternInHorizontalOrVerticalForTheOneMove : IPossibleMatchPattern
    {
        readonly MatchSomeCountInHorizontalOrVerticalPattern _matchTwoExactlyInARowOrInAColumnPattern;

        public PossibleMatch3PatternInHorizontalOrVerticalForTheOneMove()
        {
            _matchTwoExactlyInARowOrInAColumnPattern = new MatchSomeCountInHorizontalOrVerticalPattern(2, PatternOperator.Equal);
        }

        bool IPossibleMatchPattern.IsPossibleMatched(uint[,] board,
                                                     out List<List<(int row, int column, uint id)>> possibleMatches,
                                                     params uint[] skipID)
        {
            var rowsCount = board.GetLength(0);
            var columnsCount = board.GetLength(1);

            possibleMatches = new List<List<(int row, int column, uint id)>>(1);
            var isMatchedInTheRowOrInTheColumn = _matchTwoExactlyInARowOrInAColumnPattern.IsMatched(
                board, out var matchesInTheRow,
                out var matchesInTheColumn, 0);

            if (isMatchedInTheRowOrInTheColumn)
            {
                foreach (var match in matchesInTheRow)
                {
                    var potentialNeighbors = BuildPotentialNeighborsForTheRow(match);
                    DetectPossibleMatches(board, rowsCount, columnsCount, possibleMatches, potentialNeighbors, match);
                }

                foreach (var match in matchesInTheColumn)
                {
                    var potentialNeighbors = BuildPotentialNeighborsForTheColumn(match);
                    DetectPossibleMatches(board, rowsCount, columnsCount, possibleMatches, potentialNeighbors, match);
                }

                return possibleMatches.Count > 0;
            }
            else
            {
            /* 2 1 2 3
             * 1 0 2 1
             * 2 1 0 2
             */ 
            /* 1 0 1 3
            *  2 1 2 3
            *  2 2 0 2
             *
             * 2 1 2 3
            *  1 0 1 3
            *  2 2 0 2
            */
            }

            return false;
        }

        void DetectPossibleMatches(uint[,] board,
                                   int rowsCount,
                                   int columnsCount,
                                   List<List<(int row, int column, uint id)>> possibleMatches,
                                   List<(int row, int col)> neighbors,
                                   List<(int row, int column, uint id)> match)
        {
            var matchId = match[0].id;
            for (var i = 0; i < neighbors.Count; i++)
            {
                var el = neighbors[i];
                var yes = IsTheSameId(board, rowsCount, columnsCount, el, matchId);
                if (yes)
                {
                    var res = new List<(int row, int column, uint id)>
                    {
                        match[0], match[1], (el.row, el.col, matchId)
                    };
                    possibleMatches.Add(res);
                }
            }
        }

        List<(int row, int col)> BuildPotentialNeighborsForTheRow(List<(int row, int column, uint id)> match)
        {
            if (match.Count != 2)
            {
                throw new ArgumentException("It works only for matches with 2 blocks");
            }

            /* 2 1 2 3
             * 1 0 1 1
             * 2 1 0 2
             */
            var first = match[0];
            var l0 = (first.row - 1, first.column - 1);
            var l1 = (first.row, first.column - 2);
            var l2 = (first.row + 1, first.column - 1);
            /*2 3 1 3
            * 1 1 0 1
            * 2 3 1 2
            */
            var second = match[1];
            var r0 = (second.row - 1, second.column + 1);
            var r1 = (second.row, second.column + 2);
            var r2 = (second.row + 1, second.column + 1);

            var result = new List<(int row, int col)>(6)
            {
                l0, l1, l2, r0, r1, r2
            };
            return result;
        }

        List<(int row, int col)> BuildPotentialNeighborsForTheColumn(List<(int row, int column, uint id)> match)
        {
            if (match.Count != 2)
            {
                throw new ArgumentException("It works only for matches with 2 blocks");
            }

            /* 2 1 2 3
             * 1 0 1 2
             * 0 1 0 0
             * 2 1 0 2
             * 1 4 1 3
             * 5 1 3 2
             */
            var first = match[0];
            var u0 = (first.row - 2, first.column);
            var u1 = (first.row - 1, first.column - 1);
            var u2 = (first.row - 1, first.column + 1);
            /* 2 1 2 3
            * 1 0 1 2
            * 0 1 0 0
            * 2 1 0 2
            * 1 4 1 3
            * 5 1 3 2
            */
            var second = match[1];
            var d0 = (second.row + 1, second.column - 1);
            var d1 = (second.row + 2, second.column);
            var d2 = (second.row + 1, second.column + 1);

            var result = new List<(int row, int col)>(6)
            {
                u0, u1, u2, d0, d1, d2
            };
            return result;
        }

        bool IsTheSameId(uint[,] board,
                         int rowsCount,
                         int columnsCount,
                         (int row, int col) el,
                         uint id)
        {
            if (el.row >= 0 && el.row < rowsCount && el.col >= 0 && el.col < columnsCount)
            {
                return board[el.row, el.col] == id;
            }

            return false;
        }
    }
}

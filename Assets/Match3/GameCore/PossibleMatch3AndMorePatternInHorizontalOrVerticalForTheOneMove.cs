using System;
using System.Collections.Generic;

namespace Match3.GameCore
{
    public class PossibleMatch3AndMorePatternInHorizontalOrVerticalForTheOneMove : IPossibleMatchPattern
    {
        readonly MatchSomeCountInHorizontalOrVerticalPattern _matchTwoExactlyInARowOrInAColumnPattern;

        public PossibleMatch3AndMorePatternInHorizontalOrVerticalForTheOneMove()
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
            var isMatchedInTheRowOrInTheColumn = _matchTwoExactlyInARowOrInAColumnPattern.IsMatched(board, out var matchesInTheRow, 
                                           out var matchesInTheColumn, 0);
            if (isMatchedInTheRowOrInTheColumn)
            {
                
                for (var index = 0; index < matchesInTheRow.Count; index++)
                {
                    var match = matchesInTheRow[index];
                    if (match.Count != 2)
                    {
                        throw new ArgumentException("Matches in the row in size more 2");
                    }
                    /* 2 1 2 3
                     * 1 0 1 1
                     * 2 1 0 2
                     */
                }

                return false;
            }

            return false;
        }
 }
}

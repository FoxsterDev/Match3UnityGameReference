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
            possibleMatches = new List<List<(int row, int column, uint id)>>(1);
            return _matchTwoExactlyInARowOrInAColumnPattern.IsMatched(board, out var matchesInTheRow, 
                                           out var matchesInTheColumn, 0);
        }
 }
}

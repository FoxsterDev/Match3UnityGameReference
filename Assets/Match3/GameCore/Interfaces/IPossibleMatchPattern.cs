using System.Collections.Generic;

namespace Match3.GameCore
{
    public interface IPossibleMatchPattern
    {
        bool IsPossibleMatched(uint[,] board,
                               out List<List<(int row, int column, uint id)>> possibleMatches,
                               params uint[] skipID);
    }
}

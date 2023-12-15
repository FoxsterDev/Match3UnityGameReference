using System.Collections.Generic;

namespace Match3.GameCore
{
    public interface IMatchPattern
    {
        bool IsMatched(BlockEntity[,] board, 
                       out List<List<(int row, int column)>> matchesInTheRow,
                       out List<List<(int row, int column)>> matchesInTheColumn);
        bool IsMatched(uint[,] board, 
                       out List<List<(int row, int column)>> matchesInTheRow,
                       out List<List<(int row, int column)>> matchesInTheColumn);

    }
}

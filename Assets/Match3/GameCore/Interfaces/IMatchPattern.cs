using System.Collections.Generic;

namespace Match3.GameCore
{
    public interface IMatchPattern
    {
        bool IsMatched(BlockEntity[,] board, 
                       out List<List<(int row, int column, uint id)>> matchesInTheRow,
                       out List<List<(int row, int column, uint id)>> matchesInTheColumn, 
                       params uint[] skipID);

        bool IsMatched(uint[,] board, 
                       out List<List<(int row, int column, uint id)>> matchesInTheRow,
                       out List<List<(int row, int column, uint id)>> matchesInTheColumn, 
                       params uint[] skipID);

    }
}

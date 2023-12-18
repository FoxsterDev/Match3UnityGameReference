using System.Collections.Generic;

namespace Match3.GameCore
{
    public interface ICompacting
    {
        void Compact(uint[,] board,
                     out List<(int startRow, int startColumn, int targetRow, int targetColumn)> shifts, 
                     out uint[,] outBoard);
        void Compact(BlockEntity[,] board, 
                     out List<(int startRow, int startColumn, int targetRow, int targetColumn)> shifts);
    }
}

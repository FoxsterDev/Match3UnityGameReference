using System.Collections.Generic;

namespace Match3.GameCore
{
    public interface IBlocksGenerator
    {
        void Generate(uint[,] board,
                      out List<(int row, int column, uint id)> blocks,
                      out uint[,] outBoard);
    }
}

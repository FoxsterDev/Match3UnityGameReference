using System.Collections.Generic;

namespace Match3.GameCore
{
    public interface IBlocksGenerator
    {
        void Generate(BlockEntity[,] board, out List<(int row, int column, uint id)> blocks);
        void Generate(uint[,] board, out List<(int row, int column, uint id)> blocks);
    }
}

using System;

namespace Match3.GameCore
{
    public class Match3AndMoreInHorizontalOrVerticalPattern : IMatchPattern
    {
        /// <summary>
        /// it is better for testing resons
        /// </summary>
        /// <param name="board"></param>
        /// <returns>converted matrix with block id</returns>
        uint[,] ConvertBoardToIntMatrix(BlockEntity[,] board)
        {
            var rowsCount = board.GetLength(0);
            var columnsCount = board.GetLength(1);

            var matrix = new uint[rowsCount, columnsCount];
            for (var row = 0; row < rowsCount; row++)
            {
                for (var col = 0; col < columnsCount; col++)
                {
                    matrix[row, col] = board[row, col].ID;
                }
            }

            return matrix;
        }
        /// <summary>
        ///  0, 1, 0, 2
        ///  0, 0, 2, 3
        ///  0, 1, 1, 4
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsMatched(BlockEntity[,] board)
        {
            return IsMatched(ConvertBoardToIntMatrix(board));
        }

        public bool IsMatched(uint[,] board)
        {
            var rowsCount = board.GetLength(0);
            var columnsCount = board.GetLength(1);

            //check in horizontal
            var id = board[0, 0];
            var matchCount = 1;
            for (var row = 0; row < rowsCount; row++)
            {
                for (var col = 0; col < columnsCount; col++)
                {

                }
            }

            return false;
        }
    }
}

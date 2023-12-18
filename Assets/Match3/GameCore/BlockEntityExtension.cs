namespace Match3.GameCore
{
    public static class BlockEntityExtension
    {
        /// <summary>
        /// it is better for testing resons
        /// </summary>
        /// <param name="board"></param>
        /// <returns>converted matrix with block id</returns>
        public static uint[,] ConvertBoardToIntMatrix(this BlockEntity[,] board)
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

        public static string ConvertToString(this uint[,] sourceBoard)
        {
            string output = "";
            var rowsCount = sourceBoard.GetLength(0);
            var columnsCount = sourceBoard.GetLength(1);

            for (var row = 0; row < rowsCount; row++)
            {
                for (var col = 0; col < columnsCount; col++)
                {
                    output += sourceBoard[row, col] + ",";
                }

                output += "\n";
            }

            return output;
        }
        public static bool IsEqualBoardTo(this uint[,] sourceBoard, uint[,] targetBoard)
        {
            var rowsCount = sourceBoard.GetLength(0);
            var columnsCount = sourceBoard.GetLength(1);

            var rowsCount2 = targetBoard.GetLength(0);
            var columnsCount2 = targetBoard.GetLength(1);

            if (rowsCount != rowsCount2)
            {
                return false;
            }

            if (columnsCount != columnsCount2)
            {
                return false;
            }

            for (var row = 0; row < rowsCount; row++)
            {
                for (var col = 0; col < columnsCount; col++)
                {
                    if (sourceBoard[row, col] != targetBoard[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

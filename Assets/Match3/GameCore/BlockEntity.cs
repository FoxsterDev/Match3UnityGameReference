using UnityEngine;

namespace Match3.GameCore
{
    public class BlockEntity
    {
        public BlockEntity(int rowIndex,
                           int columnIndex,
                           IBlockView view,
                           IBlockUserInputEvent userInput)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            View = view;
            UserInput = userInput;
        }

        public int RowIndex { get; private set; }
        public int ColumnIndex { get; private set; }
        public IBlockView View { get; }
        public IBlockUserInputEvent UserInput { get; }

        public uint ID => View.ID;

        public void SwapWith(BlockEntity other)
        {
            var row = RowIndex;
            var column = ColumnIndex;
            RowIndex = other.RowIndex;
            ColumnIndex = other.ColumnIndex;
            other.RowIndex = row;
            other.ColumnIndex = column;

            //temp
            //sync positions
            (((MonoBehaviour) View).transform.position, ((MonoBehaviour) other.View).transform.position) =
                (((MonoBehaviour) other.View).transform.position, ((MonoBehaviour) View).transform.position);
        }

        public override string ToString()
        {
            return string.Concat(nameof(RowIndex), ":", RowIndex, ",", nameof(ColumnIndex), ":", ColumnIndex, ", ", nameof(View), ":", View.ID);
        }
    }
}

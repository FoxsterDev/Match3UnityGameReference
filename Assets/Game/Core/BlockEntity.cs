namespace Match3.GameCore
{
    public class BlockEntity
    {
        public int Index { get;  }
        public int RowIndex { get;  }
        public int ColumnIndex { get;  }
        public IBlockView View { get; }
        public IBlockUserInputEvent UserInput { get;  }

        public BlockEntity(int index,int rowIndex,int columnIndex,IBlockView view, IBlockUserInputEvent userInput)
        {
            Index = index;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            View = view;
            UserInput = userInput;
        }

        public override string ToString()
        {
            return string.Concat(nameof(RowIndex), ":", RowIndex,",", nameof(ColumnIndex), ":", ColumnIndex,", ", nameof(View), ":", View.ID);
        }
    }
}

using System.Diagnostics;
using UnityEngine;

namespace Match3.GameCore
{
    public class BlockEntity
    {
        public const uint EMPTY_ID = 0;

        Vector3 _position;

        public BlockEntity(int rowIndex,
                           int columnIndex,
                           IBlockView view,
                           IBlockUserInputEvent userInput)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            View = view;
            UserInput = userInput;
            //temp
            _position = Body.position;
            SyncName();
        }

        public int RowIndex { get; private set; }
        public int ColumnIndex { get; private set; }
        public IBlockView View { get; private set; }
        public IBlockUserInputEvent UserInput { get; private set; }

        public uint ID => View != null
                              ? View.ID
                              : EMPTY_ID;
        public bool IsEmpty => View is null;
        Transform Body => ((MonoBehaviour) View).transform;

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other">Also might be Empty block with Null View</param>
        public void SwapWith(BlockEntity other)
        {
            var row = RowIndex;
            var column = ColumnIndex;
            RowIndex = other.RowIndex;
            ColumnIndex = other.ColumnIndex;
            other.RowIndex = row;
            other.ColumnIndex = column;

            //temp
            //swap positions
            (_position, other._position) = (other._position, _position);

            if (!other.IsEmpty)
            { 
                SyncName();
                other.SyncName();
                //animate view translate
                (Body.position, other.Body.position) = (_position, other._position);
            }
            else
            {
                SyncName();
                Body.position = _position;
            }
        }

        [Conditional("UNITY_EDITOR")]
        void SyncName()
        {
            Body.name = string.Concat("Row:", RowIndex, ": Col", ColumnIndex);
        }

        public void Destroy()
        {
            var gameObject = ((MonoBehaviour) View).gameObject;
            Object.Destroy(gameObject);
            UserInput.Dispose();
            View.Dispose();
            UserInput = null;
            View = null;
        }

        public override string ToString()
        {
            return string.Concat(nameof(RowIndex), ":", RowIndex, ",", nameof(ColumnIndex), ":", ColumnIndex, ", ", nameof(View), ":", View.ID);
        }
    }
}

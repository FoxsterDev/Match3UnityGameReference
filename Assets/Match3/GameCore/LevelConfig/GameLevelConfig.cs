using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Match3.GameCore
{
    [CreateAssetMenu]
    public sealed class GameLevelConfig : ScriptableObject
    {
        [SerializeField]
        [Range(3, 10)]
        uint _columnCount = 4;
        [SerializeField]
        [Range(3, 10)]
        uint _rowCount = 4;

        /// <summary>
        /// [0,0] is the first, left up
        /// [0,1] is the second row 
        /// </summary>
        [SerializeField]
        List<BlockConfig> _blocks = new List<BlockConfig>(16);

        public uint ColumnCount => _columnCount;

        public uint RowCount => _rowCount;

        /// <summary>
        /// [0,0] is the first, left up
        /// [0,1] is the second row 
        /// </summary>
        public List<BlockConfig> Blocks => _blocks;
    }
}

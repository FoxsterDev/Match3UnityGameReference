using System.Collections.Generic;
using UnityEngine;

namespace Match3.GameCore
{
    [CreateAssetMenu]
    public sealed class GameLevelConfig : ScriptableObject
    {
        [SerializeField]
        [Range(3, 10)]
        uint _width = 4;
        [SerializeField]
        [Range(3, 10)]
        uint _height = 4;

        /// <summary>
        /// [0,0] is the first, left up
        /// [0,1] is the second row 
        /// </summary>
        [SerializeField]
        List<BlockConfig> _blocks = new List<BlockConfig>(16);
    }
}

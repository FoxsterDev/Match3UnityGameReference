using System.Collections.Generic;
using UnityEngine;

namespace Match3.GameCore
{
    [CreateAssetMenu]
    public sealed class GameLevelTemplateConfig : ScriptableObject
    {
        [SerializeField]
        [Range(3, 10)]
        uint _minColumnCount = 4;
        [SerializeField]
        [Range(3, 10)]
        uint _maxColumnCount = 10;
        [SerializeField]
        [Range(3, 10)]
        uint _minRowCount = 4;
        [SerializeField]
        [Range(3, 10)]
        uint _maxRowCount = 10;
      
        [SerializeField]
        List<BlockView> _allowedBlocks = new(5);

        [SerializeField]
        [Range(1, 4)]
        uint _minBlockId = 1;

        [SerializeField]
        [Range(2, 5)]
        uint _maxBlockId = 5;
        
        [SerializeField]
        Vector2 _offsetRoot = new Vector2(1.0f, -1.0f);

        public uint MinColumnCount => _minColumnCount;

        public uint MaxColumnCount => _maxColumnCount;

        public uint MinRowCount => _minRowCount;

        public uint MaxRowCount => _maxRowCount;

        public List<BlockView> AllowedBlocks => _allowedBlocks;

        public uint MinBlockId => _minBlockId;

        public uint MaxBlockId => _maxBlockId;

        public Vector2 OffsetRoot => _offsetRoot;
    }
}
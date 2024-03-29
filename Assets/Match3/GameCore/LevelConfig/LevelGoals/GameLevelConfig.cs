using System.Collections.Generic;
using System.Linq;
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
        List<BlockConfig> _blocks = new(16);

        [SerializeField]
        List<BlockView> _allowedBlocks = new(5);

        [SerializeField]
        [Range(1, 4)]
        uint _minBlockId = 1;

        [SerializeField]
        [Range(2, 5)]
        uint _maxBlockId = 5;

        public void Modify(uint rowCount,
                           uint columnCount,
                           List<BlockConfig> blocks, uint minBlockId, uint maxBlockId, Vector2 offsetRoot)
        {
            _rowCount = rowCount;
            _columnCount = columnCount;
            _minBlockId = minBlockId;
            _maxBlockId = maxBlockId;
            _blocks = blocks;
            _offsetRoot = offsetRoot;
        }

        public uint ColumnCount => _columnCount;

        public uint RowCount => _rowCount;

        /// <summary>
        /// [0,0] is the first, left up
        /// [0,1] is the second row
        /// </summary>
        public List<BlockConfig> Blocks => _blocks;

        public uint MinBlockId => _minBlockId;

        public uint MaxBlockId => _maxBlockId;

        public List<BlockView> AllowedBlocks => _allowedBlocks;

        public Vector2 OffsetRoot => _offsetRoot;

        [SerializeField]
        Vector2 _offsetRoot = new Vector2(1.0f, -1.0f);

        [SerializeReference] //https://blog.unity.com/engine-platform/serializereference-improvements-in-unity-2021-lts
        public List<ILevelGoal> Goals = new List<ILevelGoal>
        {
            new CollectWithId{ Count = 5, Id = 1}, 
            new FinishLevelForTheLimitedMoves{ Moves = 10},
            new FinishLevelForTheLimitedTime{ TimeInSeconds = 60}
        };

        [ContextMenu("Add Time Based Goal")]
        void AddTimeBasedGoal()
        {
            Goals.Add(new FinishLevelForTheLimitedTime{ TimeInSeconds = 30});
        }

        [ContextMenu("Add Moves Limited Goal")]
        void AddMovesLimitedGoal()
        {
            Goals.Add(new FinishLevelForTheLimitedMoves{ Moves = 10});
        }

        //to refactor
        public Sprite GetBlockSprite(uint id)
        {
            return AllowedBlocks.Find(a =>
            {
                return ((IBlockView) a).ID == id;
            }).GetComponentInChildren<SpriteRenderer>().sprite;
        }
    }
}
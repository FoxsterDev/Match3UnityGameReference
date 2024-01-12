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

        public GameLevelConfig GenerateRandom()
        {
            var column = Random.Range(_minColumnCount, _maxColumnCount + 1);
            var row = Random.Range(_minRowCount, _maxRowCount + 1);

            var count = (int) (column * row);
            var blocks = new List<BlockView>(count);
            while (count-- > 0)
            {
                var randomIndex = Random.Range(0, _allowedBlocks.Count);
                blocks.Add(_allowedBlocks[randomIndex]);
            }

            var levelConfig = ScriptableObject.CreateInstance<GameLevelConfig>();
            return levelConfig;
        }
    }
}
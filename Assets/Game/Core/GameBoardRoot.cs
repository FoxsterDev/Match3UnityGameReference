using System;
using UnityEngine;

namespace Match3.GameCore
{
    [RequireComponent(typeof(RectTransform))]
    public class GameBoardRoot : MonoBehaviour
    {
        [SerializeField]
        GameLevelConfig _levelConfig = null;

        [SerializeField]
        RectTransform _rectTransform = null;

        [SerializeField]
        GameBoardController _boardController;

        void Start()
        {
            var v = new Vector3[4];
            _rectTransform.GetWorldCorners(v);

            _boardController = new GameBoardController(_levelConfig.RowCount, _levelConfig.ColumnCount);

            //var startPosition = v[1];
            for (var row = 0; row < _levelConfig.RowCount; row++)
            {
                var startPosition = v[1];
                startPosition.y -= 1.33f * row;
                for (var col = 0; col < _levelConfig.ColumnCount; col++)
                {
                    var index = (int)(row * _levelConfig.ColumnCount + col);
                    var prefab = _levelConfig.Blocks[index].Prefab;

                    var blockInstance = Instantiate(prefab, startPosition, Quaternion.identity, _rectTransform.transform);
                    startPosition.x += 1.27f;

#if UNITY_EDITOR
                    blockInstance.name = string.Concat("Row:", row, ": Col", col);
#endif

                    var userInput = blockInstance.GetComponent<IBlockUserInputEvent>();
                    var blockView = blockInstance.GetComponent<IBlockView>();

                    _boardController.AddBlock(index, row, col, blockView, userInput);
                }
            }
        }

        void OnDestroy()
        {
            _boardController?.Dispose();
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            var v = new Vector3[4];
            _rectTransform.GetWorldCorners(v);

            for (var i = 0; i < 4; i++)
            {
                Gizmos.DrawSphere(v[i], 0.1f);
            }
        }

        void OnValidate()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
    }
}

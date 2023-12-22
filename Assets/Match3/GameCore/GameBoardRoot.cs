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
        Transform _rootTransform = null;
        
        [SerializeField]
        GameBoardController _boardController;

        void Start()
        {
            var v = new Vector3[4];
            _rectTransform.GetWorldCorners(v);

            _boardController = new GameBoardController(_levelConfig, _levelConfig.RowCount, _levelConfig.ColumnCount, _rootTransform);

            var initPosition = v[1];
            initPosition += (Vector3)_levelConfig.OffsetRoot;
            _rootTransform.localPosition = _levelConfig.OffsetRoot;

            for (var row = 0; row < _levelConfig.RowCount; row++)
            {
                var startPosition = initPosition;
                startPosition.y -= 1.33f * row;
                for (var col = 0; col < _levelConfig.ColumnCount; col++)
                {
                    var index = (int) (row * _levelConfig.ColumnCount + col);
                    var prefab = _levelConfig.Blocks[index].Prefab;

                    _boardController.CreateBlock(row, col, prefab, startPosition);

                    startPosition.x += 1.27f;
                }
            }
        }

        void OnDestroy()
        {
            _boardController?.Dispose();
        }

        void OnDrawGizmos()
        {
            var v = new Vector3[4];
            _rectTransform.GetWorldCorners(v);

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(v[0], 0.1f);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(v[1], 0.1f); 
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(v[2], 0.1f);
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(v[3], 0.1f);
        }

        void OnValidate()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
    }
}

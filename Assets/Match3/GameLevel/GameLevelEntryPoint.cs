using Match3.UI;
using UnityEngine;

namespace Match3.GameCore
{
    public class GameLevelEntryPoint : MonoBehaviour
    {
        [SerializeField]
        MonoBehaviour _gameUIBehaviour = default;

        [SerializeField]
        GameBoardRect _boardRect = default;

        [SerializeField]
        GameLevelConfig _levelConfig = default;

        GameLevelController _gameLevelController;

        IGameLevelUI UI => _gameUIBehaviour as IGameLevelUI;

        void Awake()
        {
            _gameLevelController = new GameLevelController(UI, _levelConfig, _boardRect, this);
            _gameLevelController.Initialize();
        }

        void Start()
        {
            _gameLevelController.StartLevel();
        }

        void OnDestroy()
        {
            _gameLevelController?.Dispose();
        }
    }
}

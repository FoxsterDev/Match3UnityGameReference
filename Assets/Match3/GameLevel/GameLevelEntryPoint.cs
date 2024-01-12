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

        [SerializeField]
        GameLevelTemplateConfig _levelTemplateConfig = default;

        GameLevelPlayerStartChoiceController _gameLevelPlayerStartChoiceController;

        IGameLevelUI UI => _gameUIBehaviour as IGameLevelUI;

        void Awake()
        {
            _gameLevelPlayerStartChoiceController = new GameLevelPlayerStartChoiceController(UI, _levelConfig, _levelTemplateConfig, _boardRect, this);
        }

        void Start()
        {
            _gameLevelPlayerStartChoiceController.Start();
        }

        void OnDestroy()
        {
            _gameLevelPlayerStartChoiceController?.Stop();
        }
    }
}

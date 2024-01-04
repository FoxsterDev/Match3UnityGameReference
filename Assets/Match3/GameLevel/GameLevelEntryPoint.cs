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

        GameBoardController _boardController;

        IGameLevelUI UI => _gameUIBehaviour as IGameLevelUI;

        void Awake()
        {
            UI.ResetState();
        }

        void Start()
        {
            InitializeUI();

            _boardController = new GameBoardController(
                _levelConfig,
                _boardRect);

            _boardController.CreateBoard();
        }

        void OnDestroy()
        {
            _boardController?.Dispose();
        }

        void InitializeUI()
        {
            foreach (var goal in _levelConfig.Goals)
            {
                switch (goal)
                {
                    case FinishLevelForTheLimitedMoves mov:
                        UI.SetMoves(mov.Moves);
                        break;
                    case FinishLevelForTheLimitedTime time:
                        UI.SetAvailableTime(time.TimeInSeconds);
                        break;
                    case CollectWithId block:
                        UI.SetBlockGoal(block.Count, _levelConfig.GetBlockSprite(block.Id));
                        break;
                }
            }
        }
    }
}

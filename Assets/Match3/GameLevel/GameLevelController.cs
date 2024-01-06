using System;
using Match3.UI;

namespace Match3.GameCore
{
    public class GameLevelController : IDisposable
    {
        readonly IGameLevelUI _ui;
        GameBoardController _boardController;
        readonly GameBoardRect _boardRect;
        readonly GameLevelConfig _levelConfig;

        public GameLevelController(IGameLevelUI ui,
                                   GameLevelConfig levelConfig,
                                   GameBoardRect boardRect)
        {
            _boardRect = boardRect;
            _levelConfig = levelConfig;
            _ui = ui;
        }

        public void Dispose()
        {
            _boardController?.Dispose();
        }

        public void Initialize()
        {
            _ui.ResetState();
        }

        public void StartLevel()
        {
            InitializeUI();

            _boardController = new GameBoardController(
                _levelConfig,
                _boardRect);

            _boardController.CreateBoard();
        }

        void InitializeUI()
        {
            foreach (var goal in _levelConfig.Goals)
            {
                switch (goal)
                {
                    case FinishLevelForTheLimitedMoves mov:
                        _ui.SetMoves(mov.Moves);
                        break;
                    case FinishLevelForTheLimitedTime time:
                        _ui.SetAvailableTime(time.TimeInSeconds);
                        break;
                    case CollectWithId block:
                        _ui.SetBlockGoal(block.Count, _levelConfig.GetBlockSprite(block.Id));
                        break;
                }
            }
        }
    }
}

using System;
using Match3.GameCore;
using UnityEngine;

namespace Match3.UI
{
    public class GameLevelPlayerStartChoiceController : IGameLevelPlayResultConnector, IDisposable
    {
        readonly GameBoardRect _boardRect;
        readonly MonoBehaviour _coroutineRunner;
        readonly GameLevelTemplateConfig _levelTemplateConfig;
        readonly GameLevelConfig _regularLevelConfig;
        readonly IGameLevelUI _ui;
        GameLevelController _levelController;

        public GameLevelPlayerStartChoiceController(IGameLevelUI ui,
                                                    GameLevelConfig regularLevelConfig,
                                                    GameLevelTemplateConfig levelTemplateConfig,
                                                    GameBoardRect boardRect,
                                                    MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _boardRect = boardRect;
            _regularLevelConfig = regularLevelConfig;
            _levelTemplateConfig = levelTemplateConfig;
            _ui = ui;
        }

        void IDisposable.Dispose()
        {
        }

        void IGameLevelPlayResultConnector.FinishedLevelEvent(uint score)
        {
            _ui.FinishUI.Show($"You finished the level\n Your score is {score}");
            _ui.FinishUI.RandomPlayButtonClick += FinishUI_OnRandomPlayButtonClick;
            _ui.FinishUI.ReplayButtonClick += OnReplayButtonClick;
            _levelController?.Stop();
            _levelController = null;
            var prevScore = PlayerPrefs.GetInt("TheBestScore", 0);
            if (score > prevScore)
            {
                PlayerPrefs.SetInt("TheBestScore", (int)score);
                PlayerPrefs.Save();
            }
        }

        public void Start()
        {
            _ui.ResetState();
            _ui.StartUI.Show(PlayerPrefs.GetInt("TheBestScore", 0).ToString());
            _ui.StartUI.PlayButtonClick += OnPlayButtonClick;
            _ui.StartUI.RandomPlayButtonClick += OnRandomPlayButtonClick;
        }

        public void Stop()
        {
            _ui.StartUI.PlayButtonClick -= OnPlayButtonClick;
            _ui.StartUI.RandomPlayButtonClick -= OnRandomPlayButtonClick;

            _ui.FinishUI.RandomPlayButtonClick -= FinishUI_OnRandomPlayButtonClick;
            _ui.FinishUI.ReplayButtonClick -= OnReplayButtonClick;
            ((IDisposable) this).Dispose();
        }

        void OnRandomPlayButtonClick()
        {
            _ui.StartUI.Hide();
            var template = _levelTemplateConfig;
        }

        void OnPlayButtonClick()
        {
            _ui.StartUI.Hide();
            _levelController = new GameLevelController(
                this,
                _ui,
                _regularLevelConfig,
                _boardRect,
                _coroutineRunner);

            _levelController.Start();
        }

        void OnReplayButtonClick()
        {
            _ui.FinishUI.Hide();
            _levelController = new GameLevelController(
                this,
                _ui,
                _regularLevelConfig,
                _boardRect,
                _coroutineRunner);

            _levelController.Start();
        }

        void FinishUI_OnRandomPlayButtonClick()
        {
            _ui.FinishUI.Hide();
            OnRandomPlayButtonClick();
        }
    }
}

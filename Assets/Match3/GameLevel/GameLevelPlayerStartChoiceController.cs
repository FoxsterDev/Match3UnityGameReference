using System;
using Match3.GameCore;
using UnityEngine;

namespace Match3.UI
{
    public class GameLevelPlayerStartChoiceController : IDisposable
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

        public void Start()
        {
            _ui.StartUI.Show("1240");
            _ui.StartUI.PlayButtonClick += OnPlayButtonClick;
            _ui.StartUI.RandomPlayButtonClick += OnRandomPlayButtonClick;
        }

        public void Stop()
        {
            _ui.StartUI.PlayButtonClick -= OnPlayButtonClick;
            _ui.StartUI.RandomPlayButtonClick -= OnRandomPlayButtonClick;
            ((IDisposable) this).Dispose();
        }

        void OnRandomPlayButtonClick()
        {
            var template = _levelTemplateConfig;
        }

        void OnPlayButtonClick()
        {
            _ui.StartUI.Hide();
            _levelController = new GameLevelController(
                _ui,
                _regularLevelConfig,
                _boardRect,
                _coroutineRunner);
            _levelController.Start();
            //StartLevel();
        }
    }
}

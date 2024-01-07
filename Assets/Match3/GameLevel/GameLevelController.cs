using System;
using System.Collections;
using System.Collections.Generic;
using Match3.UI;
using UnityEngine;
using UnityEngine.Assertions;

namespace Match3.GameCore
{
    public class GameLevelController : IGameBoardConnector, IDisposable
    {
        readonly GameBoardRect _boardRect;
        readonly GameLevelConfig _levelConfig;
        readonly IGameLevelUI _ui;

        uint _availableMoves, _availableTime;

        GameBoardController _boardController;
        readonly MonoBehaviour _coroutineRunner;

        //rethink
        ScoreController _scoreController;

        Coroutine _timerCoroutine;

        bool IsLevelFinished = false;

        public GameLevelController(IGameLevelUI ui,
                                   GameLevelConfig levelConfig,
                                   GameBoardRect boardRect,
                                   MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _boardRect = boardRect;
            _levelConfig = levelConfig;
            _ui = ui;
        }

        uint AvailableMoves
        {
            get => _availableMoves;
            set
            {
                if (_availableMoves != value)
                {
                    _availableMoves = value;
                    _ui.SetMoves(value);
                }
            }
        }

        uint AvailableTimeInSeconds
        {
            get => _availableTime;
            set
            {
                if (_availableTime != value)
                {
                    _availableTime = value;
                    _ui.SetAvailableTime(value);

                    if (_availableTime == 0)
                    {
                        //_timerCoroutine = null;
                        FinishLevel();
                    }
                }
            }
        }
        public void Dispose()
        {
            _boardController?.Dispose();
        }

        bool IGameBoardConnector.IsBlockMovementEligible(out string errorReason)
        {
            errorReason = string.Empty;
            if (IsLevelFinished)
            {
                errorReason = "IsLevelFinished";
                return false;
            }

            if (AvailableMoves == 0)
            {
                errorReason = "Zero available moves";
                return false;
            }

            return AvailableMoves > 0;
        }

        void IGameBoardConnector.InitiatedBlockMovementEvent()
        {
            AvailableMoves -= 1;
            if (_availableMoves == 0)
            {
                FinishLevel();
            }
        }

        void IGameBoardConnector.BlockMatchesEvent(List<List<(int row, int column, uint id)>> matchesInTheRow,
                                                   List<List<(int row, int column, uint id)>> matchesInTheColumn)
        {
            _scoreController.CalculateScoreForTheMatches(matchesInTheRow, matchesInTheColumn);
        }

        public void Initialize()
        {
            _ui.ResetState();

            InitializeUI();
            _scoreController = new ScoreController(_levelConfig);
            _boardController = new GameBoardController(
                _levelConfig,
                _boardRect, this);

            _boardController.CreateBoard();
        }

        public void StartLevel()
        {
            if (AvailableTimeInSeconds > 0)
            {
                 Assert.IsNull(_timerCoroutine, "_timerCoroutine == null");
                _timerCoroutine = _coroutineRunner.StartCoroutine(StartTimer(1));
            }
        }

        void FinishLevel()
        {
            IsLevelFinished = true;
            //block all inputs
            //show finish window panel
            if (_timerCoroutine != null)
            {
                _coroutineRunner.StopCoroutine(_timerCoroutine);
                _timerCoroutine = null;
            }
        }

        IEnumerator StartTimer(uint delay)//check resume
        {
            var delayObj = new WaitForSecondsRealtime(delay);
            do
            {
                yield return delayObj;
                delayObj.Reset();
                AvailableTimeInSeconds -= delay;
            }
            while (AvailableTimeInSeconds > 0);
        }

        void InitializeUI()
        {
            foreach (var goal in _levelConfig.Goals)
            {
                switch (goal)
                {
                    case FinishLevelForTheLimitedMoves mov:
                        AvailableMoves = mov.Moves;
                        break;
                    case FinishLevelForTheLimitedTime time:
                        AvailableTimeInSeconds = time.TimeInSeconds;
                        break;
                    case CollectWithId block:
                        _ui.SetBlockGoal(block.Count, _levelConfig.GetBlockSprite(block.Id));
                        break;
                }
            }
        }

    }
}

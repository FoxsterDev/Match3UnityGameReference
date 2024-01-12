using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Match3.UI;
using UnityEngine;
using UnityEngine.Assertions;

namespace Match3.GameCore
{
    public class GameLevelController : IGameBoardConnector, IDisposable
    {
        readonly GameBoardRect _boardRect;
        readonly MonoBehaviour _coroutineRunner;

        readonly Dictionary<uint, uint> _goals = new(1);
        readonly GameLevelConfig _levelConfig;
        readonly IGameLevelUI _ui;
        uint _availableMoves, _availableTime;
        GameBoardController _boardController;
        bool _isLevelFinished = false;

        //rethink
        ScoreController _scoreController;

        //state
        Coroutine _timerCoroutine;

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
        }

        bool IGameBoardConnector.IsBlockMovementEligible(out string errorReason)
        {
            errorReason = string.Empty;
            if (_isLevelFinished)
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
            if (AvailableMoves == 0)
            {
                FinishLevel();
            }
        }

        void IGameBoardConnector.BlockMatchesEvent(List<List<(int row, int column, uint id)>> matchesInTheRow,
                                                   List<List<(int row, int column, uint id)>> matchesInTheColumn)
        {
            _scoreController.CalculateScoreForTheMatches(matchesInTheRow, matchesInTheColumn);
            for (var index = 0; index < matchesInTheRow.Count; index++)
            {
                var e = matchesInTheRow[index];
                UpdateGoal(e[0].id, (uint) e.Count);
            }

            for (var index = 0; index < matchesInTheColumn.Count; index++)
            {
                var e = matchesInTheColumn[index];
                UpdateGoal(e[0].id, (uint) e.Count);
            }

            if (IsAllGoalsReached())
            {
                FinishLevel();
            }
        }

        public void Stop()
        {
            _boardController?.Dispose();
            Dispose();
        }

        public void Start()
        {
            CreateBoard();

            if (AvailableTimeInSeconds > 0)
            {
                Assert.IsNull(_timerCoroutine, "_timerCoroutine == null");
                _timerCoroutine = _coroutineRunner.StartCoroutine(StartTimer(1));
            }
        }

        void CreateBoard()
        {
            InitializeUI();
            _scoreController = new ScoreController(_levelConfig);
            _boardController = new GameBoardController(
                _levelConfig,
                _boardRect, this);

            _boardController.CreateBoard();
        }

        void FinishLevel()
        {
            _isLevelFinished = true;
            //block all inputs
            //show finish window panel
            if (_timerCoroutine != null)
            {
                _coroutineRunner.StopCoroutine(_timerCoroutine);
                _timerCoroutine = null;
            }

            _ui.FinishUI.Show($"You finished the level\n Your score is {UnityEngine.Random.Range(100, 1000)}");
        }

        IEnumerator StartTimer(uint delay) //check resume
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

        void UpdateGoal(uint blockId, uint count)
        {
            var cur = _goals.TryGetValue(blockId, out var current);
            if (current > 0)
            {
                _goals[blockId] -= Math.Min(current, count);
                _ui.SetBlockGoal(_goals[blockId], _levelConfig.GetBlockSprite(blockId));
            }
        }

        bool IsAllGoalsReached()
        {
            return _goals.Values.All(e => e == 0);
        }

        void InitializeUI()
        {
            _ui.ResetState();

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
                        _goals[block.Id] = block.Count;
                        break;
                }
            }
        }
    }
}

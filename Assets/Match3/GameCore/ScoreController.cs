using System;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.GameCore
{
    public class ScoreController : IDisposable
    {
         uint _totalScore;
        public ScoreController(GameLevelConfig levelConfig)
        {
        }

        public uint TotalScore => _totalScore;

        void IDisposable.Dispose()
        {
        }

        public uint CalculateScoreForTheMatches(List<List<(int row, int column, uint id)>> matchesInTheRow,
                                                List<List<(int row, int column, uint id)>> matchesInTheColumn)
        {
           
            uint k = 20;
            foreach (var match in matchesInTheRow)
            {
                var str = string.Join("::", match);
                Debug.Log("Is pattern found: " + str);
                _totalScore += match[0].id * k;
            }

            k = 50;
            foreach (var match in matchesInTheColumn)
            {
                var str = string.Join("::", match);
                Debug.Log("Is pattern found: " + str);
                _totalScore += match[0].id * k;
            }

            return _totalScore;
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.GameCore
{
    public class ScoreController : IDisposable
    {
        public ScoreController(GameLevelConfig levelConfig)
        {
        }

        public void Dispose()
        {
        }

        public void CalculateScoreForTheMatches(List<List<(int row, int column, uint id)>> matchesInTheRow,
                                                List<List<(int row, int column, uint id)>> matchesInTheColumn)
        {
            foreach (var match in matchesInTheRow)
            {
                var str = string.Join("::", match);
                Debug.Log("Is pattern found: " + str);
            }

            foreach (var match in matchesInTheColumn)
            {
                var str = string.Join("::", match);
                Debug.Log("Is pattern found: " + str);
            }
        }
    }
}

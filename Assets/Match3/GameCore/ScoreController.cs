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

        public void CalculateScoreForTheMatches(List<List<(int row, int column)>> matchesInTheRow,
                                                List<List<(int row, int column)>> matchesInTheColumn)
        {
            foreach (var match in matchesInTheRow)
            {
                var str = string.Join("::", match);
                Debug.Log("Is pattern found: "+ str);
            }
            foreach (var match in matchesInTheColumn)
            {
                var str = string.Join("::", match);
                Debug.Log("Is pattern found: "+ str);
            }
        }
        
        public void Dispose()
        {
            
        }
    }
}

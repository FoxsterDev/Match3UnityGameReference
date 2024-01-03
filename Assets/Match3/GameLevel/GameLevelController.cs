
using Match3.UI;
using UnityEngine;

namespace Match3.GameCore
{
    public class GameLevelController : MonoBehaviour
    {

        [SerializeField]
        MonoBehaviour _gameUIBehaviour = default;

        [SerializeField]
        GameLevelConfig _levelConfig = default;

        IGameLevelUI UI => _gameUIBehaviour as IGameLevelUI;

        void Awake()
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
                        UI.SetBlockGoal(block.Count, null);
                        break;
                }
            }
        }
    }
}

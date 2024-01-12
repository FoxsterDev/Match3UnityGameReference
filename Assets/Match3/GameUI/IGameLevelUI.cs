using UnityEngine;

namespace Match3.UI
{
    public interface IGameLevelUI
    {
        IGameLevelFinishUI FinishUI { get; }
        IGameLevelStartUI StartUI { get; }
        void ResetState();
        void SetMoves(uint moves);
        void SetAvailableTime(uint seconds);
        void SetScore(uint score);
        void SetBlockGoal(uint count, Sprite blockSprite);
    }
}

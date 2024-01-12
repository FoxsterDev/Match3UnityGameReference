using UnityEngine;

namespace Match3.UI
{
    public interface IGameLevelUI
    {
        void ResetState();
        void SetMoves(uint moves);
        void SetAvailableTime(uint seconds);
        void SetBlockGoal(uint count, Sprite blockSprite);
        
        IGameLevelFinishUI FinishUI { get; }
        IGameLevelStartUI StartUI { get; }
    }
}
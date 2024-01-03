using UnityEngine;

namespace Match3.UI
{
    public interface IGameLevelUI
    {
        void SetMoves(uint moves);
        void SetAvailableTime(uint seconds);
        void SetBlockGoal(uint count, Sprite blockSprite);
    }
}

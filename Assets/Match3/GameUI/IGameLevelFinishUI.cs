using UnityEngine.Events;

namespace Match3.UI
{
    public interface IGameLevelFinishUI
    {
        void Show(string text);
        void Hide();
        event UnityAction ReplayButtonClick;
        event UnityAction RandomPlayButtonClick;
    }
}
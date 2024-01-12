using UnityEngine.Events;

namespace Match3.UI
{
    public interface IGameLevelStartUI
    {
        void Show(string previousBestScore);
        void Hide();
        event UnityAction PlayButtonClick;
        event UnityAction RandomPlayButtonClick;
    }
}

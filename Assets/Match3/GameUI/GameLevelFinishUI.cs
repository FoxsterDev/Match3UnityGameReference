using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Match3.UI
{
    public class GameLevelFinishUI : MonoBehaviour, IGameLevelFinishUI
    {
        [SerializeField]
        Button _randomPlayButton;

        [SerializeField]
        Button _replayPlayButton;

        [SerializeField]
        TMP_Text _descriptionLabel;

        void IGameLevelFinishUI.Show(string text)
        {
            ResetState();
            SetDescription(text);
            SetActive(true);
        }

        void IGameLevelFinishUI.Hide()
        {
            SetActive(false);
        }

        event UnityAction IGameLevelFinishUI.ReplayButtonClick
        {
            add => _replayPlayButton.onClick.AddListener(value);
            remove => _replayPlayButton.onClick.RemoveAllListeners();
        }

        event UnityAction IGameLevelFinishUI.RandomPlayButtonClick
        {
            add => _randomPlayButton.onClick.AddListener(value);
            remove => _randomPlayButton.onClick.RemoveAllListeners();
        }

        void ResetState()
        {
            _descriptionLabel.text = string.Empty;
        }

        void SetDescription(string text)
        {
            _descriptionLabel.text = text;
        }

        void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}

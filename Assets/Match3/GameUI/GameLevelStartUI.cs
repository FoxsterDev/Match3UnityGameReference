using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Match3.UI
{
    public class GameLevelStartUI : MonoBehaviour, IGameLevelStartUI
    {
        [SerializeField]
        Button _randomPlayButton;

        [SerializeField]
        Button _playButton;

        [SerializeField]
        TMP_Text _descriptionLabel;

        void IGameLevelStartUI.Show(string previousBestScore)
        {
            SetDescription("The best previous score is " + previousBestScore);
            SetActive(true);
        }

        void IGameLevelStartUI.Hide()
        {
            SetActive(false);
        }

        event UnityAction IGameLevelStartUI.PlayButtonClick
        {
            add => _playButton.onClick.AddListener(value);
            remove => _playButton.onClick.RemoveListener(value);
        }

        event UnityAction IGameLevelStartUI.RandomPlayButtonClick
        {
            add => _randomPlayButton.onClick.AddListener(value);
            remove => _randomPlayButton.onClick.RemoveListener(value);
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

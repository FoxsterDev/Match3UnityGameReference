using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Match3.UI
{
    public class GameLevelFinishUI : MonoBehaviour, IGameLevelFinishUI
    {
        [SerializeField] private Button _randomPlayButton;
        [SerializeField] private Button _replayPlayButton;
        [SerializeField] private TMP_Text _descriptionLabel;

         void ResetState()
         {
             _descriptionLabel.text = string.Empty;
         }

         void IGameLevelFinishUI.Show(string text)
         {
             ResetState();
             SetDescription(text);
        }

         void IGameLevelFinishUI.Hide()
        {
            SetActive(false);
        }

         void SetDescription(string text)
        {
            _descriptionLabel.text = text;
        }

         void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        event UnityAction IGameLevelFinishUI.ReplayButtonClick
        {
            add
            {
                _replayPlayButton.onClick.AddListener(value);
            }
            remove
            {
                _replayPlayButton.onClick.RemoveAllListeners();
            }
        }

        event UnityAction IGameLevelFinishUI.RandomPlayButtonClick 
        {
            add
            {
                _randomPlayButton.onClick.AddListener(value);
            }
            remove
            {
                _randomPlayButton.onClick.RemoveAllListeners();
            }
        }
    }
}
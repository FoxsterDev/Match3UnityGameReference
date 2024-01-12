using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Match3.UI
{
    public class GameLevelStartUI : MonoBehaviour, IGameLevelStartUI
    {
        [SerializeField] private Button _randomPlayButton;
        [SerializeField] private Button _playButton;
        [SerializeField] private TMP_Text _descriptionLabel;


        void IGameLevelStartUI.Show(string previousBestScore)
        {
            SetDescription("The best previous score is " + previousBestScore);
            SetActive(true);
        }

        void IGameLevelStartUI.Hide()
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
    }
}
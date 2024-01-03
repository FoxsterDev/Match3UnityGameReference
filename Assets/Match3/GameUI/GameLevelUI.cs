using System;
using System.Collections;
using System.Collections.Generic;
using Match3.GameCore;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    public class GameLevelUI : MonoBehaviour, IGameLevelUI
    {
        [SerializeField]
        TMP_Text _goalMovesCountLabel = default;

        [SerializeField]
        TMP_Text _goalTimeLabel = default;

        [SerializeField]
        TMP_Text _goalBlockCountLabel = default;

        [SerializeField]
        Image _goalStatusImage = default;

       
        public void SetMoves(uint moves)
        {
            _goalMovesCountLabel.text = moves + " moves";
        }

        public void SetAvailableTime(uint seconds)
        {
            _goalTimeLabel.text = seconds + " sec";
        }

        public void SetBlockGoal(uint count, Sprite blockSprite)
        {
            _goalStatusImage.sprite = blockSprite;
            _goalBlockCountLabel.text = count.ToString();
        }
    }
}

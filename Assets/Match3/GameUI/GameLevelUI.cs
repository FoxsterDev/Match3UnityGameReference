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

        [SerializeField]
        MonoBehaviour _gameLevelFinishUIBehaviour;

        [SerializeField]
        MonoBehaviour _gameLevelStartUIBehaviour;

        void IGameLevelUI.ResetState()
        {
            _goalMovesCountLabel.enabled = false;
            _goalTimeLabel.enabled = false;
            _goalStatusImage.enabled = false;
            _goalBlockCountLabel.enabled = false;
        }

        void IGameLevelUI.SetMoves(uint moves)
        {
            _goalMovesCountLabel.text = moves.ToString() + " moves";
            _goalMovesCountLabel.enabled = true;
        }

        void IGameLevelUI.SetAvailableTime(uint seconds)
        {
            _goalTimeLabel.text = seconds + " sec";
            _goalTimeLabel.enabled = true;
        }

        void IGameLevelUI.SetBlockGoal(uint count, Sprite blockSprite)
        {
            _goalStatusImage.sprite = blockSprite;
            _goalBlockCountLabel.text = count.ToString();

            _goalStatusImage.enabled = true;
            _goalBlockCountLabel.enabled = true;
        }

        public IGameLevelFinishUI FinishUI => (IGameLevelFinishUI) _gameLevelFinishUIBehaviour;
        public IGameLevelStartUI StartUI => (IGameLevelStartUI) _gameLevelStartUIBehaviour;
    }
}

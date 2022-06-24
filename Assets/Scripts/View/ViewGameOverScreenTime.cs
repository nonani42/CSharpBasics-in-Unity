using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ballgame
{
    public class ViewGameOverScreenTime
    {
        private Text _labelText;

        public ViewGameOverScreenTime(GameObject _gameOverTime)
        {
            _labelText = _gameOverTime.GetComponent<Text>();
            _labelText.text = string.Empty;
        }

        public void GameOver(TimerController timer)
        {
            _labelText.text = $"Game over. You've been killed by {timer}.";
        }

    }
}

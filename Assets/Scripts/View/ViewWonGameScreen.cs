using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ballgame
{
    public class ViewWonGameScreen
    {
        private Text _labelText;

        public ViewWonGameScreen(GameObject winScreen)
        {
            _labelText = winScreen.GetComponent<Text>();
            _labelText.text = string.Empty;
        }

        public void GameWon(int bonusCount)
        {
            _labelText.text = $"Congratulations! You've won! You've collected {bonusCount} bonuses.";
        }
    }
}

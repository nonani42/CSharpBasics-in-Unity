using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ballgame
{
    public class ViewWonGame
    {
        private Text _labelText;

        public ViewWonGame(GameObject winScreen)
        {
            _labelText = winScreen.GetComponent<Text>();
            _labelText.text = string.Empty;
        }

        public void GameWon(string bonusCount, Color color)
        {
            _labelText.text = $"Congratulations! You've won! You've collected {bonusCount} bonuses.";
        }
    }
}

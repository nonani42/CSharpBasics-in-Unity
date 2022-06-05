using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ballgame
{
    public class ViewBadBonus
    {
        private Text _labelText;

        public ViewBadBonus(GameObject badBonusPrefab)
        {
            _labelText = badBonusPrefab.GetComponent<Text>();
            _labelText.text = string.Empty;
        }

        public void GameOver(string name, Color color)
        {
            _labelText.text = $"Game over. Bonus name: {name} and color: {color}";
        }

    }
}

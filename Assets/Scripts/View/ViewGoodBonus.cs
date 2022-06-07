using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ballgame
{
    public class ViewGoodBonus
    {
        private Text _labelText;

        public ViewGoodBonus(GameObject goodBonusPrefab)
        {
            _labelText = goodBonusPrefab.GetComponent<Text>();
            _labelText.text = string.Empty;
        }

        public void Display(int count)
        {
            _labelText.text = $"Bonus count: {count}";
        }
    }
}

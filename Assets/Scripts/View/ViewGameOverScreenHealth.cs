using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ballgame
{
    public class ViewGameOverScreenHealth
    {
        private Text _labelText;

        public ViewGameOverScreenHealth(GameObject badBonusPrefab)
        {
            _labelText = badBonusPrefab.GetComponent<Text>();
            _labelText.text = string.Empty;
        }

        public void GameOver(Bonus obj)
        {
            (Vector3 pos, int value, string name) = obj;
            _labelText.text = $"Game over. You've been killed by {name} at {pos}.";
        }

    }
}

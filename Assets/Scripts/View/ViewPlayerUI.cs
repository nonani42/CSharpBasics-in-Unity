using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ballgame
{
    public class ViewPlayerUI
    {
        private Text _labelText;

        public ViewPlayerUI(GameObject playerUI)
        {
            _labelText = playerUI.GetComponent<Text>();
            _labelText.text = string.Empty;
        }

        public void Display(int count)
        {
            _labelText.text = $"Health: {count}";
        }
    }
}

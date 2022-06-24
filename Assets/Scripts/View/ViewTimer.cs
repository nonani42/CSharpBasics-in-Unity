using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ballgame
{
    public class ViewTimer
    {
        private Text _labelText;

        public ViewTimer(GameObject timer)
        {
            _labelText = timer.GetComponent<Text>();
            _labelText.text = string.Empty;
        }

        public void Display(string count)
        {
            _labelText.text = $"Time left: {count}";
        }
    }
}

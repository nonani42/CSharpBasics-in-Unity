using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ballgame
{
    public class ViewGoal
    {
        private Text _labelText;

        public ViewGoal(GameObject _goalView)
        {
            _labelText = _goalView.GetComponent<Text>();
            _labelText.text = string.Empty;
        }

        public void Display(int count)
        {
            _labelText.text = $"Goal: collect {count} good bonuses!";
        }
    }
}

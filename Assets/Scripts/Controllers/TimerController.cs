using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public class TimerController : IExecute
    {
        public event Action<string> OnTick = delegate (string time) { };
        public event Action<TimerController> OnTimesUp = delegate (TimerController timer) { };

        bool _isRunning;
        float remainingTime;

        int minutes;
        int seconds;
        string timeToString;

        public TimerController(float time)
        {
            remainingTime = time;
            _isRunning = true;
            TimeToDisplay();
        }


        public void Update()
        {
            if (_isRunning)
            {
                if (remainingTime > 0)
                {
                    remainingTime -= Time.deltaTime;
                    Debug.Log("OnUpdate");
                    if (Mathf.FloorToInt(remainingTime % 60) != seconds)
                    {
                        TimeToDisplay();
                    }
                }
                else
                {
                    remainingTime = 0f;
                    TimeToDisplay();
                    OnTimesUp(this);
                    _isRunning = false;
                }
            }
        }

        private void TimeToDisplay()
        {
            minutes = Mathf.FloorToInt(remainingTime / 60);
            seconds = Mathf.FloorToInt(remainingTime % 60);
            timeToString = $"{minutes:00}:{seconds:00}";
            OnTick(timeToString);
            Debug.Log("OnTickAction");
        }
    }
}

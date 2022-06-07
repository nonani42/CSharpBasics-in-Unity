using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Ballgame
{
    public class BadBonus : Bonus
    {
        public float flightHeight;
        public float rotationSpeed;

        public event Action<string, Color> OnCaughtPlayer = delegate (string str, Color color) { };

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            flightHeight = Random.Range(1f, 4f);
            rotationSpeed = Random.Range(20f, 40f);
        }

        protected override void Interaction()
        {
            OnCaughtPlayer.Invoke(gameObject.name, _color);
        }
    }
}

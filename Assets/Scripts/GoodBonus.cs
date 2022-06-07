using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Ballgame
{
    public class GoodBonus : Bonus
    {
        public float flightHeight;
        [SerializeField] public Material _material;
        public int _points;

        public event Action<int> AddPoints = delegate (int points) { };

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            flightHeight = Random.Range(1f, 4f);
            _material = GetComponent<Renderer>().material;
            _points = 1;
        }

        protected override void Interaction()
        {
            AddPoints.Invoke(_points);
        }
    }
}
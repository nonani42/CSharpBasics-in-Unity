using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Ballgame
{
    public class GoodBonus : Bonus, IFly, IFlicker
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

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, flightHeight), _transform.position.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1f));
        }

        public override void Update()
        {
            Fly();
            Flicker();
        }

        protected override void Interaction()
        {
            AddPoints.Invoke(_points);
        }
    }
}
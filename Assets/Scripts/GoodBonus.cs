using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Ballgame
{
    public class GoodBonus : Bonus, IFly, IFlicker, IInteractable
    {
        private float flightHeight;
        [SerializeField] private Material _material;
        private int _points;

        public event Action<int> AddPoints = delegate (int points) { };

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            flightHeight = Random.Range(1f, 2f);
            _material = GetComponent<Renderer>().material;
            _points = 2;
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
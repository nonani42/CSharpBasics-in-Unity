using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Ballgame
{
    public class BadBonus : Bonus, IRotate, IFly, IInteractable
    {
        private float flightHeight;
        private float rotationSpeed;

        public event Action<string, Color> OnCaughtPlayer = delegate (string str, Color color) { };

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            flightHeight = Random.Range(1f, 2f);
            rotationSpeed = Random.Range(20f, 40f);
        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, flightHeight), _transform.position.z);
        }

        public void Rotate()
        {
            _transform.Rotate(Vector3.up * (Time.deltaTime * rotationSpeed), Space.World);
        }

        public override void Update()
        {
            Fly();
            Rotate();
        }

        protected override void Interaction()
        {
            OnCaughtPlayer.Invoke(gameObject.name, _color);
        }
    }
}

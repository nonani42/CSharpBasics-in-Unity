using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public class BadBonus : Bonus, IRotate, IFly, IInteractable
    {
        private float flightHeight;
        private float rotationSpeed;

        private void Awake()
        {
            flightHeight = Random.Range(1f, 5f);
            rotationSpeed = Random.Range(13f, 40f);
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

        }
    }
}

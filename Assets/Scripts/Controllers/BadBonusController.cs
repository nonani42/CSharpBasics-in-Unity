using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public class BadBonusController : BonusController, IRotate, IFly
    {
        private BadBonus _badBonus;
        private float _flightHeight;
        private float _rotationSpeed;

        public BadBonusController(BadBonus badBonus)
        {
            _badBonus = badBonus;
            _transform = badBonus._transform;
            _flightHeight = badBonus.flightHeight;
            _rotationSpeed = badBonus.rotationSpeed;
        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, _flightHeight), _transform.position.z);
        }

        public void Rotate()
        {
            _transform.Rotate(Vector3.up * (Time.deltaTime * _rotationSpeed), Space.World);
        }

        public override void Update()
        {
            Fly();
            Rotate();
            if (Input.GetKeyDown(KeyCode.K))
            {
                _badBonus.Save();
            }
        }
    }
}

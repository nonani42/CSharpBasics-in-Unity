using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public class GoodBonusController : BonusController, IFly, IFlicker
    {
        private GoodBonus _goodBonus;
        private float _flightHeight;
        private Material _material;

        public GoodBonusController(GoodBonus goodBonus)
        {
            _goodBonus = goodBonus;
            _transform = goodBonus.transform;
            _flightHeight = goodBonus.flightHeight;
            _material = goodBonus._material;
        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, _flightHeight), _transform.position.z);
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

    }
}

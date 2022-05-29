using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public sealed class Player : Unit
    {

        void Awake()
        {
            _transform = transform;
            if (GetComponent<Rigidbody>())
            {
                _rb = GetComponent<Rigidbody>();
            }
            isDead = false;
            Health = 100f;
            Speed = 5f;
        }

        public override void Move(float x, float y, float z)
        {
            if(_rb)
            {
                _rb.AddForce(new Vector3(x, y, z) * Speed);
            }
            else
            {
                Debug.Log("No Rigidbody");
            }
        }
    }
}

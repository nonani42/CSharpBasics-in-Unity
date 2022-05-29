using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] public Rigidbody _rb;
        public Transform _transform;

        public static float Speed = 5f;
        public static float Health = 100f;
        public static bool isDead;

        public abstract void Move(float x, float y, float z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public abstract class Unit : MonoBehaviour
    {
        [Header("For debug")]
        [SerializeField] public Rigidbody _rb;
        public Transform _transform;

        public static float Speed;
        public int Health;
        protected static bool isDead;


        public abstract void Move(float x, float y, float z);
        public abstract void Save();
    }
}

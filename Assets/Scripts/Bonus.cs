using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public abstract class Bonus : MonoBehaviour, IExecute
    {
        private bool _isInteractive;
        public Transform _transform;

        public bool IsInteractive 
        {
            get 
            { 
                return _isInteractive; 
            }
            private set
            {
                _isInteractive = value;
                GetComponent<Renderer>().enabled = value;
                GetComponent<Collider>().enabled = value;
            }
        }

        void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        void Start()
        {
            IsInteractive = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction();
                IsInteractive = false;
            }
        }

        protected abstract void Interaction();

        public abstract void Update();
    }
}

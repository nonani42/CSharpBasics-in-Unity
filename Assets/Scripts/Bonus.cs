using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public abstract class Bonus : MonoBehaviour, IInteractable, IExecute
    {
        private bool _isInteractive;
        public Transform _transform;
        protected Color _color;

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

        void Start()
        {
            IsInteractive = true;
            _color = Random.ColorHSV();
            if(TryGetComponent(out Renderer renderer))
            {
                renderer.sharedMaterial.color = _color;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsInteractive || other.CompareTag("Player"))
            {
                Interaction();
                IsInteractive = false;
            }
        }

        public abstract void Update();

        protected abstract void Interaction();

    }
}

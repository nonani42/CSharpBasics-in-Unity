using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public struct BonusData: IData
    {
        public string BonusName;
        public bool BonusInteractive;
        public SVect3 BonusPosition;
    }

    public abstract class Bonus : MonoBehaviour, IInteractable
    {
        protected BonusData BonusData;
        protected ISaveData<BonusData> _data;

        protected bool _isInteractive;
        public Transform _transform;
        protected Color _color;

        protected Reference _ref;
        protected GameObject _dot;

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

                _dot.GetComponent<Renderer>().enabled = value;
                _dot.GetComponent<Renderer>().enabled = value;
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

        protected abstract void Interaction();
        public abstract void Save();
        public abstract void CreateDot();

    }
}

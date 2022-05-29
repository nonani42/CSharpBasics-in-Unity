using System;
using UnityEngine;

namespace Ballgame
{
    public class Main : MonoBehaviour
    {
        private ListExecuteObjects _intereactiveObjects;
        private InputController _inputController;

        [SerializeField] private GameObject _player;


        void Awake()
        {
            _inputController = new InputController(_player.GetComponent<Unit>());
            _intereactiveObjects = new ListExecuteObjects();
            _intereactiveObjects.AddExecuteObject(_inputController);
        }

        void Update()
        {
            for (int i = 0; i < _intereactiveObjects.Length; i++)
            {
                if(_intereactiveObjects[i] == null)
                {
                    continue;
                }
                _intereactiveObjects[i].Update();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public class CameraController : IExecute
    {
        private Transform _player;
        private Transform _cameraTransform;
        private Vector3 _offset;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _cameraTransform = mainCamera;

            _cameraTransform.LookAt(_player);
            _offset = _cameraTransform.position - _player.position;
        }

        public void Update()
        {
            _cameraTransform.position = _player.position + _offset;
        }
    }
}

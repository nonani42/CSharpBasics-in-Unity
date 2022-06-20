using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public class MinimapCamera : MonoBehaviour
    {
        public Shader _replShader;
        private Camera _camera;

        private void Awake()
        {
            _replShader = Shader.Find("Unlit/Texture");
            _camera = GetComponent<Camera>();

            if (_replShader)
            {
                _camera.SetReplacementShader(_replShader, "Rendertype");
            }
        }

        private void OnDisable()
        {
            _camera.ResetReplacementShader();
        }
    }
}

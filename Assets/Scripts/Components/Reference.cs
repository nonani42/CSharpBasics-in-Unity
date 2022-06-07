using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public sealed class Reference
    {
        private GameObject _goodBonus;
        private GameObject _badBonus;
        private GameObject _restartBtn;
        private GameObject _winScreen;


        private Canvas _canvas;
        private Camera _mainCamera;

        public GameObject GoodBonus
        {
            get
            {
                if(_goodBonus == null)
                {
                    GameObject temp = Resources.Load<GameObject>("UI/GoodBonus");
                    _goodBonus = Object.Instantiate(temp, Canvas.transform);
                }
                return _goodBonus;
            }
            set => _goodBonus = value;
        }

        public GameObject BadBonus
        {
            get
            {
                if (_badBonus == null)
                {
                    GameObject temp = Resources.Load<GameObject>("UI/GameOver");
                    _badBonus = Object.Instantiate(temp, Canvas.transform);
                }
                return _badBonus;
            }
            set => _badBonus = value;
        }

        public GameObject WinScreen
        {
            get
            {
                if (_winScreen == null)
                {
                    GameObject temp = Resources.Load<GameObject>("UI/Win");
                    _winScreen = Object.Instantiate(temp, Canvas.transform);
                }
                return _winScreen;
            }
            set => _winScreen = value;
        }

        public GameObject RestartBtn
        {
            get
            {
                if (_restartBtn == null)
                {
                    GameObject temp = Resources.Load<GameObject>("UI/RestartBtn");
                    _restartBtn = Object.Instantiate(temp, Canvas.transform);
                }
                return _restartBtn;
            }
            set => _restartBtn = value;
        }

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
            set => _canvas = value;
        }

        public Camera MainCamera
        {
            get
            {
                if (!_mainCamera)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
            set => _mainCamera = value;
        }
    }
}

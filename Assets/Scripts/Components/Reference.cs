using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

using Object = UnityEngine.Object;
using System.Xml.Serialization;

namespace Ballgame
{
    public sealed class Reference
    {
        private string _path;

        private GameObject _goodBonus;
        private GameObject _badBonus;
        private GameObject _restartBtn;
        private GameObject _winScreen;

        private GameObject _goodBonusPrefab;
        private GameObject _badBonusPrefab;
        private List<Vector3> _points;

        private GameObject _bonusDotPrefab;

        private Canvas _canvas;
        private Camera _mainCamera;

        public GameObject BonusDotPrefab
        {
            get
            {
                if (_bonusDotPrefab == null)
                {
                    _bonusDotPrefab = Resources.Load<GameObject>("UI/BonusDot");
                }
                return _bonusDotPrefab;
            }
            set => _bonusDotPrefab = value;
        }

        public GameObject GoodBonusPrefab
        {
            get
            {
                if (_goodBonusPrefab == null)
                {
                    _goodBonusPrefab = Resources.Load<GameObject>("Bonus/GoodBonus");
                }
                return _goodBonusPrefab;
            }
            set => _goodBonusPrefab = value;
        }

        public GameObject BadBonusPrefab
        {
            get
            {
                if (_badBonusPrefab == null)
                {
                    _badBonusPrefab = Resources.Load<GameObject>("Bonus/BadBonus");
                }
                return _badBonusPrefab;
            }
            private set => _badBonusPrefab = value;
        }

        public List<Vector3> BonusPoints
        {
            get
            {
                if (_points == null)
                {
                    _points = new List<Vector3>();
                    _path = Path.Combine(Application.dataPath + "/WaypointData/BonusMap_Maze_01.xml");
                    if (!File.Exists(_path))
                    {
                        Debug.Log("File doesn't exist");
                        return _points;
                    }

                    XmlSerializer serializer = new(typeof(SVect3[]));
                    using (FileStream reader = new(_path, FileMode.Open))
                    {
                        SVect3[] temp = (SVect3[])serializer.Deserialize(reader);
                        foreach(var t in temp)
                        {
                            _points.Add(t);
                        }
                    }
                }
                return _points;
            }
            private set => _points = value;
        }


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

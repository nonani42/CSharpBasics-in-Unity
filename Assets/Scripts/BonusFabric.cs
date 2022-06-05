using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;
using Object = UnityEngine.Object;


namespace Ballgame
{
    public class BonusFabric
    {
        private List<Transform> _points;
        private GameObject _goodBonusPrefab;
        private GameObject _badBonusPrefab;
        private int _goodBonusAmount;
        private int _badBonusAmount;

        public BonusFabric()
        {
            _goodBonusPrefab = GoodBonusPrefab;
            _badBonusPrefab = BadBonusPrefab;
            _points = Points;

            DividePoints();
        }

        private void DividePoints()
        {
            _goodBonusAmount = Points.Count / 2;
            _badBonusAmount = Points.Count - _goodBonusAmount;
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
            private set => _goodBonusPrefab = value;
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

        public List<Transform> Points
        {
            get
            {
                if (_points == null)
                {
                    GameObject temp = Object.Instantiate(Resources.Load<GameObject>("Bonus/SpawnBonuses"));
                    _points = new List<Transform>();
                    foreach (Transform child in temp.transform)
                    {
                        _points.Add(child);
                    }
                }
                return _points;
            }
            private set => _points = value;
        }

        public List<IExecute> CreateBonuses()
        {
            int r;
            List<IExecute> temp = new();
            for (int i = 0; i < _goodBonusAmount; i++)
            {
                r = Random.Range(0, (Points.Count));
                temp.Add(Object.Instantiate(GoodBonusPrefab, Points[r]).GetComponent<IExecute>());
                Points.Remove(Points[r]);
            }
            for (int i = 0; i < _badBonusAmount; i++)
            {
                r = Random.Range(0, (Points.Count));
                temp.Add(Object.Instantiate(BadBonusPrefab, Points[r]).GetComponent<IExecute>());
                Points.Remove(Points[r]);
            }
            return temp;
        }
    }
}

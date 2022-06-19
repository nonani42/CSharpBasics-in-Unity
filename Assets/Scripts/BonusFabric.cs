using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;
using Object = UnityEngine.Object;


namespace Ballgame
{
    public class BonusFabric
    {
        private Reference _ref;
        private List<Transform> _points;
        private GameObject _goodBonusPrefab;
        private GameObject _badBonusPrefab;
        private int _goodBonusAmount;
        private int _badBonusAmount;

        public BonusFabric()
        {
            _ref = new Reference();
            _goodBonusPrefab = _ref.GoodBonusPrefab;
            _badBonusPrefab = _ref.BadBonusPrefab;
            _points = _ref.BonusPoints;

            DividePoints();
        }

        public int GoodBonusAmount { get => _goodBonusAmount; private set => _goodBonusAmount = value; }

        private void DividePoints()
        {
            GoodBonusAmount = _points.Count / 2;
            _badBonusAmount = _points.Count - GoodBonusAmount;
        }

        public List<Bonus> CreateBonuses()
        {
            int r;
            List<Bonus> result = new();
            GameObject temp;
            for (int i = 0; i < GoodBonusAmount; i++)
            {
                r = Random.Range(0, (_points.Count));
                temp = Object.Instantiate(_goodBonusPrefab, _points[r]);
                temp.transform.parent = null;
                result.Add(temp.GetComponent<Bonus>());
                _points.Remove(_points[r]);
            }
            for (int i = 0; i < _badBonusAmount; i++)
            {
                r = Random.Range(0, (_points.Count));
                temp = Object.Instantiate(_badBonusPrefab, _points[r]);
                temp.transform.parent = null;
                result.Add(temp.GetComponent<Bonus>());
                _points.Remove(_points[r]);
            }
            return result;
        }
    }
}

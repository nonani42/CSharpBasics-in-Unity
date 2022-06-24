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
        private List<Vector3> _points;
        private GameObject _goodBonusPrefab;
        private GameObject _badBonusPrefab;

        private GameObject _badBonusParent;
        private GameObject _goodBonusParent;


        private int _bonusAmount;
        private int _goodBonusAmount;
        private int _badBonusAmount;

        public BonusFabric()
        {
            _badBonusParent = new GameObject("BadBonuses");
            _goodBonusParent = new GameObject("GoodBonuses");

            _ref = new Reference();
            _goodBonusPrefab = _ref.GoodBonusPrefab;
            _badBonusPrefab = _ref.BadBonusPrefab;
            _points = _ref.BonusPoints;
            _bonusAmount = _points.Count;
        }

        public int GoodBonusAmount
        {
            get
            {
                if (_goodBonusAmount == 0)
                {
                    _goodBonusAmount = _bonusAmount / 2;
                }
                return _goodBonusAmount;
            }
            private set => _goodBonusAmount = value;
        }

        public int BadBonusAmount
        {
            get
            {
                if (_badBonusAmount == 0)
                {
                    _badBonusAmount = _bonusAmount - GoodBonusAmount;
                }
                return _badBonusAmount;
            }
            private set => _badBonusAmount = value;
        }

        public List<Bonus> CreateBonuses()
        {
            int r;
            List<Bonus> result = new();
            GameObject temp;
            for (int i = 0; i < GoodBonusAmount; i++)
            {
                r = Random.Range(0, (_points.Count));
                temp = Object.Instantiate(_goodBonusPrefab, _points[r], Quaternion.identity);
                temp.transform.parent = _goodBonusParent.transform;
                result.Add(temp.GetComponent<Bonus>());
                _points.Remove(_points[r]);
            }
            for (int i = 0; i < BadBonusAmount; i++)
            {
                r = Random.Range(0, (_points.Count));
                temp = Object.Instantiate(_badBonusPrefab, _points[r], Quaternion.identity);
                temp.transform.parent = _badBonusParent.transform;
                result.Add(temp.GetComponent<Bonus>());
                _points.Remove(_points[r]);
            }
            return result;
        }
    }
}

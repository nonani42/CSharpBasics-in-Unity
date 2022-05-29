using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;


namespace Ballgame
{
    public class BonusFabric : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;
        [SerializeField] private GameObject _goodBonusPrefab;
        [SerializeField] private GameObject _badBonusPrefab;
        private int _goodBonusAmount;
        private int _badBonusAmount;
        List<Transform> _pointsList;

        private void Awake()
        {
            _pointsList = new List<Transform>();
            _pointsList.AddRange(_points);
            _goodBonusAmount = _pointsList.Count / 2;
            _badBonusAmount = _pointsList.Count - _goodBonusAmount;
        }

        public Bonus[] CreateBonuses()
        {
            int r;
            List<Bonus> temp = new();
            for (int i = 0; i < _goodBonusAmount; i++)
            {
                r = Random.Range(0, (_pointsList.Count));
                temp.Add(Instantiate(_goodBonusPrefab, _pointsList[r]).GetComponent<Bonus>());
                _pointsList.Remove(_pointsList[r]);
            }
            for (int i = 0; i < _badBonusAmount; i++)
            {
                r = Random.Range(0, (_pointsList.Count));
                temp.Add(Instantiate(_badBonusPrefab, _pointsList[r]).GetComponent<Bonus>());
                _pointsList.Remove(_pointsList[r]);
            }
            return temp.ToArray();
        }

        void Update()
        {
        
        }
    }
}

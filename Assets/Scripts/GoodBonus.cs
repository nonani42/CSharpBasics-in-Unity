using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Ballgame
{
    public class GoodBonus : Bonus
    {
        public float flightHeight;
        [SerializeField] public Material _material;
        public int _points;

        public event Action<int> AddPoints = delegate (int points) { };

        private void Awake()
        {
            BonusData = new BonusData();
            _data = new JSONData<BonusData>();

            _transform = GetComponent<Transform>();
            flightHeight = Random.Range(1f, 4f);
            _material = GetComponent<Renderer>().material;
            _points = 1;

            _ref = new();
            CreateDot();
        }

        protected override void Interaction()
        {
            AddPoints.Invoke(_points);
        }

        public override void Save()
        {
            BonusData.BonusName = gameObject.name;
            BonusData.BonusInteractive = _isInteractive;
            BonusData.BonusPosition = _transform.position;

            _data.Save(BonusData);

            BonusData newGBonus = _data.Load();
            Debug.Log(newGBonus.BonusName);
            Debug.Log(newGBonus.BonusInteractive);
            Debug.Log($"Position:{newGBonus.BonusPosition.X}, {newGBonus.BonusPosition.Y}, {newGBonus.BonusPosition.Z}");
        }

        public override void CreateDot()
        {
            _dot = Instantiate(_ref.BonusDotPrefab, new Vector3(_transform.position.x, 50, _transform.position.z), _transform.rotation);
        }
    }
}
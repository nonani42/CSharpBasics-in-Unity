using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Ballgame
{
    public class BadBonus : Bonus
    {
        public float flightHeight;
        public float rotationSpeed;

        public event Action<Bonus> OnCaughtPlayer = delegate (Bonus obj) { };

        private void Awake()
        {
            BonusData = new BonusData();
            _data = new JSONData<BonusData>();
            _transform = GetComponent<Transform>();
            flightHeight = Random.Range(1f, 4f);
            rotationSpeed = Random.Range(20f, 40f);
            _points = 1;

            _ref = new();
            CreateDot();
        }

        protected override void Interaction()
        {
            OnCaughtPlayer.Invoke(this);
        }

        public override void Deconstruct(out Vector3 pos, out int points, out string name)
        {
            (pos, points, name) = (_transform.position, _points, gameObject.name);
        }

        public override void Save()
        {
            BonusData.BonusName = gameObject.name;
            BonusData.BonusInteractive = _isInteractive;
            BonusData.BonusPosition = _transform.position;

            _data.Save(BonusData);

            BonusData newBBonus = _data.Load();
            Debug.Log(newBBonus.BonusName);
            Debug.Log(newBBonus.BonusInteractive);
            Debug.Log($"Position:{newBBonus.BonusPosition.X}, {newBBonus.BonusPosition.Y}, {newBBonus.BonusPosition.Z}");
        }

        public override void CreateDot()
        {
            _dot = Instantiate(_ref.BonusDotPrefab, new Vector3(_transform.position.x, 50, _transform.position.z), _transform.rotation);
        }
    }
}

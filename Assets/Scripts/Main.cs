using System;
using UnityEngine;

namespace Ballgame
{
    public class Main : MonoBehaviour
    {
        private ListExecuteObjects _intereactiveObjects;
        private ListBonusObjects _bonusObjects;

        private InputController _inputController;
        private BonusFabric _bonusFabric;

        [SerializeField] private GameObject _player;


        void Awake()
        {
            _inputController = new InputController(_player.GetComponent<Unit>());
            _intereactiveObjects = new ListExecuteObjects();
            _bonusObjects = new ListBonusObjects();
            _bonusFabric = FindObjectOfType<BonusFabric>();
            _intereactiveObjects.AddExecuteObject(_inputController);
            GetBonuses();
            SetEvents();
        }

        private void SetEvents()
        {
            foreach (var bonus in _bonusObjects)
            {
                if(bonus is GoodBonus)
                {
                    (bonus as GoodBonus).AddPoints += GoodThing;
                }
                else if(bonus is BadBonus)
                {
                    (bonus as BadBonus).OnCaughtPlayer += BadThing;
                }
            }
        }

        private void GetBonuses()
        {
            Bonus[] temp = _bonusFabric.CreateBonuses();
            foreach (var bonus in temp)
            {
                _bonusObjects.AddBonusObject(bonus);
            }
        }

        void Update()
        {
            for (int i = 0; i < _intereactiveObjects.Length; i++)
            {
                if(_intereactiveObjects[i] == null)
                {
                    continue;
                }
                _intereactiveObjects[i].Update();
            }
        }

        private void BadThing(string str, Color color)
        {
            Debug.Log($"Collected {str} colored {color}");
        }

        private void GoodThing(int points)
        {
            Debug.Log($"Collected good bonus, added points: {points}");
        }

    }
}

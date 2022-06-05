using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ballgame
{
    public class Main : MonoBehaviour
    {
        private ListExecuteObjects _intereactiveObjects;

        private InputController _inputController;
        private BonusFabric _bonusFabric;
        private ViewGoodBonus _viewGoodBonus;
        private ViewBadBonus _viewBadBonus;
        private Reference _ref;

        private int _bonusCount;

        [SerializeField] private GameObject _player;


        void Awake()
        {
            Time.timeScale = 1f;
            _inputController = new InputController(_player.GetComponent<Unit>());
            _intereactiveObjects = new ListExecuteObjects();
            _bonusFabric = new BonusFabric();
            _ref = new Reference();
            _viewGoodBonus = new ViewGoodBonus(_ref.GoodBonus);
            _viewBadBonus = new ViewBadBonus(_ref.BadBonus);
            _ref.RestartBtn.SetActive(false);
            _ref.RestartBtn.GetComponent<Button>().onClick.AddListener(RestartGame);

            _intereactiveObjects.AddExecuteObject(_inputController);
            GetBonuses();


            SetEvents();
        }

        private void SetEvents()
        {
            foreach (var bonus in _intereactiveObjects)
            {
                if(bonus is GoodBonus _bonusG)
                {
                    _bonusG.AddPoints += AddBonus;
                }
                else if(bonus is BadBonus _bonusB)
                {
                    _bonusB.OnCaughtPlayer += EndGame;
                }
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void AddBonus(int value)
        {
            _bonusCount += value;
            _viewGoodBonus.Display(_bonusCount);
        }

        private void EndGame(string name, Color color)
        {
            _ref.RestartBtn.SetActive(true);
            Time.timeScale = 0f;
            _viewBadBonus.GameOver(name, color);
        }

        private void GetBonuses()
        {
            List<IExecute> temp = _bonusFabric.CreateBonuses();
            foreach (var bonus in temp)
            {
                _intereactiveObjects.AddExecuteObject(bonus);
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

    }
}

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
        private List<Bonus> _bonusList;

        private InputController _inputController;
        private CameraController _cameraController;
        private BonusFabric _bonusFabric;
        private ViewGoodBonus _viewGoodBonus;
        private ViewBadBonus _viewBadBonus;
        private ViewWonGame _viewWonGame;
        private Reference _reference;

        private int _bonusCount;
        private int _bonusToWin;

        [SerializeField] private GameObject _player;

        public event Action<string, Color> Win = delegate (string bonusCount, Color color) { };

        void Awake()
        {
            Time.timeScale = 1f;

            _intereactiveObjects = new ListExecuteObjects();
            _reference = new Reference();
            _reference.RestartBtn.SetActive(false);
            _inputController = new InputController(_player.GetComponent<Unit>());
            _cameraController = new CameraController(_player.transform, _reference.MainCamera.transform);
            _bonusFabric = new BonusFabric();
            _viewGoodBonus = new ViewGoodBonus(_reference.GoodBonus);
            _viewBadBonus = new ViewBadBonus(_reference.BadBonus);
            _viewWonGame = new ViewWonGame(_reference.WinScreen);
            _reference.RestartBtn.GetComponent<Button>().onClick.AddListener(RestartGame);

            _intereactiveObjects.AddExecuteObject(_inputController);
            _intereactiveObjects.AddExecuteObject(_cameraController);
            GetBonuses();

            SetEvents();
        }

        private void SetEvents()
        {
            foreach (var bonus in _bonusList)
            {
                if(bonus is GoodBonus _bonusG)
                {
                    _bonusG.AddPoints += AddBonus;
                }
                else if(bonus is BadBonus _bonusB)
                {
                    _bonusB.OnCaughtPlayer += EndGame;
                    _bonusB.OnCaughtPlayer += _viewBadBonus.GameOver;
                }
            }
            Win += EndGame;
            Win += _viewWonGame.GameWon;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void AddBonus(int value)
        {
            _bonusCount += value;
            _viewGoodBonus.Display(_bonusCount);
            if(_bonusCount >= _bonusToWin)
            {
                Win.Invoke(_bonusCount.ToString(), Color.white);
            }
        }

        private void EndGame(string name, Color color)
        {
            _reference.RestartBtn.SetActive(true);
            Time.timeScale = 0f;
        }

        private void GetBonuses()
        {
            _bonusList = _bonusFabric.CreateBonuses();
            foreach (var bonus in _bonusList)
            {
                if (bonus is GoodBonus _bonusG)
                {
                    _intereactiveObjects.AddExecuteObject(new GoodBonusController(_bonusG));
                }
                else if (bonus is BadBonus _bonusB)
                {
                    _intereactiveObjects.AddExecuteObject(new BadBonusController(_bonusB));
                }
            }
            _bonusToWin = _bonusFabric.GoodBonusAmount;
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

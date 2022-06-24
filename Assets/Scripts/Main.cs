using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ballgame
{
    public class Main : MonoBehaviour
    {
        private ListExecuteObjects _executiveObjects;
        private List<Bonus> _bonusList;

        private InputController _inputController;
        private CameraController _cameraController;
        private BonusFabric _bonusFabric;
        private ViewGoodBonus _viewGoodBonus;
        private ViewGameOverScreenHealth _viewGameOverScreenHealth;
        private ViewGameOverScreenTime _viewGameOverScreenTime;
        private ViewWonGameScreen _viewWonGame;
        private ViewPlayerUI _viewPlayerUI;
        private ViewGoal _viewGoal;
        private ViewTimer _viewTimer;

        private Reference _reference;

        private TimerController _timer;
        [SerializeField] private float _time = 300f;


        private int _bonusCount;
        private int _bonusToWin;
        [Header("Add in editor")]
        [SerializeField] private GameObject _playerObj;
        private Player _player;


        public event Action<int> OnWin = delegate (int bonusCount) { };
        public event Action<Bonus> OnLose = delegate (Bonus obj) { };


        void Awake()
        {
            Time.timeScale = 1f;

            _executiveObjects = new ListExecuteObjects();
            _reference = new Reference();
            _inputController = new InputController(_playerObj.GetComponent<Unit>());
            _cameraController = new CameraController(_playerObj.transform, _reference.MainCamera.transform);
            _bonusFabric = new BonusFabric();
            _viewGoodBonus = new ViewGoodBonus(_reference.GoodBonus);
            _viewGameOverScreenHealth = new ViewGameOverScreenHealth(_reference.BadBonus);
            _viewWonGame = new ViewWonGameScreen(_reference.WinScreen);
            _viewPlayerUI = new ViewPlayerUI(_reference.PlayerUI);
            _viewGoal = new ViewGoal(_reference.GoalView);
            _viewTimer = new ViewTimer(_reference.Timer);
            _viewGameOverScreenTime = new ViewGameOverScreenTime(_reference.GameOverTime);
            _timer = new TimerController(_time);

            _player = _playerObj.GetComponent<Player>();
            _reference.RestartBtn.GetComponent<Button>().onClick.AddListener(RestartGame);


            _executiveObjects.AddExecuteObject(_inputController);
            _executiveObjects.AddExecuteObject(_cameraController);
            _executiveObjects.AddExecuteObject(_timer);
            GetBonuses();

            SetEvents();


            _reference.RestartBtn.SetActive(false);
            _viewPlayerUI.Display(_player.Health);
            _viewGoal.Display(_bonusToWin);
        }

        private void SetEvents()
        {
            _player.Hit +=_viewPlayerUI.Display;
            _timer.OnTimesUp += _viewGameOverScreenTime.GameOver;
            _timer.OnTimesUp += StopGame;
            foreach (var bonus in _bonusList)
            {
                if(bonus is GoodBonus _bonusG)
                {
                    _bonusG.AddPoints += AddBonus;
                }
                else if(bonus is BadBonus _bonusB)
                {
                    _bonusB.OnCaughtPlayer += _player.GetHit;
                    _bonusB.OnCaughtPlayer += GameOver;
                }
            }
            OnWin += _viewWonGame.GameWon;
            OnLose += _viewGameOverScreenHealth.GameOver;
            _timer.OnTick += _viewTimer.Display;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void AddBonus(Bonus obj)
        {
            (Vector3 pos, int value, string name) = obj;
            _bonusCount += value;
            _viewGoodBonus.Display(_bonusCount);
            if (_bonusCount >= _bonusToWin)
            {
                OnWin.Invoke(_bonusCount);
                StopGame(obj);
            }
        }

        private void GameOver(Bonus obj)
        {
            if (_player.IsDead)
            {
                OnLose.Invoke(obj);
                StopGame(obj);
            }
        }

        private void StopGame(System.Object obj)
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
                    _executiveObjects.AddExecuteObject(new GoodBonusController(_bonusG));
                }
                else if (bonus is BadBonus _bonusB)
                {
                    _executiveObjects.AddExecuteObject(new BadBonusController(_bonusB));
                }
            }
            _bonusToWin = _bonusFabric.GoodBonusAmount;
        }

        void Update()
        {
            for (int i = 0; i < _executiveObjects.Length; i++)
            {
                if(_executiveObjects[i] == null)
                {
                    continue;
                }
                _executiveObjects[i].Update();

            }
        }
    }
}

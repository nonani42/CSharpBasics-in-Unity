using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public struct PlayerData: IData
    {
        public string PlayerName;
        public int PlayerHealth;
        public float PlayerSpeed;
        public bool PlayerDead;
        public SVect3 PlayerPosition;
    }

    public sealed class Player : Unit
    {
        PlayerData SinglePlayerData;
        private ISaveData<PlayerData> _data;

        [Header("Add in editor")]
        [SerializeField] Transform _playerDot;


        public event Action<int> Hit = delegate (int health) { };


        public bool IsDead {
            get 
            {
                if (Health <= 0) 
                {
                    isDead = true;
                }
                return isDead;
            }
            private set => isDead = value; }


        void Awake()
        {
            _transform = transform;
            if (GetComponent<Rigidbody>())
            {
                _rb = GetComponent<Rigidbody>();
            }
            IsDead = false;
            Health = 3;
            Speed = 5f;

            SinglePlayerData = new PlayerData();
            _data = new XMLData<PlayerData>();
        }

        public override void Move(float x, float y, float z)
        {
            if(_rb)
            {
                _rb.AddForce(new Vector3(x, y, z) * Speed);
                _playerDot.position = new Vector3(_transform.position.x, _playerDot.position.y, _transform.position.z);
            }
            else
            {
                Debug.Log("No Rigidbody");
            }
        }

        public void GetHit(Bonus obj)
        {
            (Vector3 pos, int value, string name) = obj;
            Health -= value;
            Hit.Invoke(Health);
        }


        public override void Save()
        {
            SinglePlayerData.PlayerName = gameObject.name;
            SinglePlayerData.PlayerHealth = Health;
            SinglePlayerData.PlayerSpeed = Speed;
            SinglePlayerData.PlayerDead = IsDead;
            SinglePlayerData.PlayerPosition = _transform.position;

            _data.Save(SinglePlayerData);

            PlayerData newPlayer = _data.Load();
            Debug.Log(newPlayer.PlayerName);
            Debug.Log(newPlayer.PlayerHealth);
            Debug.Log(newPlayer.PlayerSpeed);
            Debug.Log(newPlayer.PlayerDead);
            Debug.Log($"Position:{newPlayer.PlayerPosition.X}, {newPlayer.PlayerPosition.Y}, {newPlayer.PlayerPosition.Z}");
        }
    }
}

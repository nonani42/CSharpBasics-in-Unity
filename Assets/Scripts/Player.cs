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
        void Awake()
        {
            _transform = transform;
            if (GetComponent<Rigidbody>())
            {
                _rb = GetComponent<Rigidbody>();
            }
            isDead = false;
            Health = 100;
            Speed = 5f;

            SinglePlayerData = new PlayerData();
            _data = new XMLData<PlayerData>();
        }

        public override void Move(float x, float y, float z)
        {
            if(_rb)
            {
                _rb.AddForce(new Vector3(x, y, z) * Speed);
            }
            else
            {
                Debug.Log("No Rigidbody");
            }
        }

        public override void Save()
        {
            SinglePlayerData.PlayerName = gameObject.name;
            SinglePlayerData.PlayerHealth = Health;
            SinglePlayerData.PlayerSpeed = Speed;
            SinglePlayerData.PlayerDead = isDead;
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

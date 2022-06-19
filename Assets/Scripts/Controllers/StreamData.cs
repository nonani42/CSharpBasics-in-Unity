using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace Ballgame
{
    public class StreamData: ISaveData<PlayerData>
    {
        string SavePath = Path.Combine(Application.dataPath, "StreamData.abc");

        public void Save(PlayerData player)
        {
            using(StreamWriter _writer = new StreamWriter(SavePath))
            {
                _writer.WriteLine(player.PlayerName);
                _writer.WriteLine(player.PlayerHealth);
                _writer.WriteLine(player.PlayerSpeed);
                _writer.WriteLine(player.PlayerDead);
                _writer.WriteLine(player.PlayerPosition.X);
                _writer.WriteLine(player.PlayerPosition.Y);
                _writer.WriteLine(player.PlayerPosition.Z);
            }
        }

        public PlayerData Load()
        {
            PlayerData result = new PlayerData();
            if (!File.Exists(SavePath))
            {
                Debug.Log("File doesn't exist");
                return result;
            }
            using (StreamReader _reader = new StreamReader(SavePath))
            {
                result.PlayerName = _reader.ReadLine();
                result.PlayerHealth = Convert.ToInt32(_reader.ReadLine());
                result.PlayerSpeed = Convert.ToSingle(_reader.ReadLine());
                result.PlayerDead = Convert.ToBoolean(_reader.ReadLine());
                result.PlayerPosition.X = Convert.ToSingle(_reader.ReadLine());
                result.PlayerPosition.Y = Convert.ToSingle(_reader.ReadLine());
                result.PlayerPosition.Z = Convert.ToSingle(_reader.ReadLine());
            }
            return result;
        }
    }
}

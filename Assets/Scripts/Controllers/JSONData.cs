using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace Ballgame
{
    public class JSONData<TType> : ISaveData<TType>
        where TType : IData, new()
    {
        string _fileName;
        string _savePath;
        Crypto cript = new();

        public string SavePath
        {
            get
            {
                if (_savePath == null)
                {
                    _fileName = $"JSONData{Guid.NewGuid().ToString().Substring(0, 5)}.json";
                    _savePath = Path.Combine(Application.dataPath, _fileName);
                }
                return _savePath;
            }
            set
            {
                _savePath = value;
            }
        }

        public void Save(TType saveStruct)
        {
            string FileJSON = JsonUtility.ToJson(saveStruct);
            File.WriteAllText(SavePath, cript.Encript(FileJSON)); 
        }

        public TType Load()
        {
            TType result = new();
            if (!File.Exists(SavePath))
            {
                Debug.Log("File doesn't exist");
                return result;
            }
            string tempJSON = File.ReadAllText(SavePath);
            result = JsonUtility.FromJson<TType>(cript.Encript(tempJSON));
            return result;
        }
    }
}

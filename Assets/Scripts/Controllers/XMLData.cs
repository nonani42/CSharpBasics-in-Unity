using System;
using System.IO;
using System.Xml;
using UnityEngine;

namespace Ballgame
{
    public class XMLData<TType> : ISaveData<TType>
        where TType: IData, new()
    {
        string _fileName;
        string _savePath;
        TType _savedStruct;

        public string SavePath
        {
            get
            {
                if (_savePath == null)
                {
                    _fileName = $"{typeof(TType).Name}-{Guid.NewGuid().ToString().Substring(0, 5)}.xml";
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
            _savedStruct = saveStruct;

            XmlDocument xmlDoc = new();
            XmlNode rootNode;
            XmlElement element;

            if (saveStruct is PlayerData _pData)
            {
                rootNode = xmlDoc.CreateElement("Player");
                xmlDoc.AppendChild(rootNode);

                element = xmlDoc.CreateElement("PlayerName");
                element.SetAttribute("value", _pData.PlayerName);
                rootNode.AppendChild(element);

                element = xmlDoc.CreateElement("PlayerHealth");
                element.SetAttribute("value", _pData.PlayerHealth.ToString());
                rootNode.AppendChild(element);

                element = xmlDoc.CreateElement("PlayerSpeed");
                element.SetAttribute("value", _pData.PlayerSpeed.ToString());
                rootNode.AppendChild(element);

                element = xmlDoc.CreateElement("PlayerDead");
                element.SetAttribute("value", _pData.PlayerDead.ToString());
                rootNode.AppendChild(element);

                element = xmlDoc.CreateElement("PlayerPosition");
                element.SetAttribute("Xvalue", _pData.PlayerPosition.X.ToString());
                element.SetAttribute("Yvalue", _pData.PlayerPosition.Y.ToString());
                element.SetAttribute("Zvalue", _pData.PlayerPosition.Z.ToString());
                rootNode.AppendChild(element);
            }
            else if (saveStruct is BonusData _bData) 
            {
                rootNode = xmlDoc.CreateElement("Bonus");
                xmlDoc.AppendChild(rootNode);

                element = xmlDoc.CreateElement("BonusName");
                element.SetAttribute("value", _bData.BonusName);
                rootNode.AppendChild(element);

                element = xmlDoc.CreateElement("BonusInteractive");
                element.SetAttribute("value", _bData.BonusInteractive.ToString());
                rootNode.AppendChild(element);

                element = xmlDoc.CreateElement("BonusPosition");
                element.SetAttribute("Xvalue", _bData.BonusPosition.X.ToString());
                element.SetAttribute("Yvalue", _bData.BonusPosition.Y.ToString());
                element.SetAttribute("Zvalue", _bData.BonusPosition.Z.ToString());
                rootNode.AppendChild(element);
            }
            else
            {
                Debug.Log("No known structure to save!");
            }

            xmlDoc.Save(SavePath);
        }

        public TType Load()
        {
            if (!File.Exists(SavePath))
            {
                Debug.Log("File doesn't exist");
                return new();
            }

            if (_savedStruct is PlayerData)
            {
                PlayerData result = new();

                using (XmlTextReader reader = new(SavePath))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement("PlayerName"))
                        {
                            result.PlayerName = reader.GetAttribute("value");
                        }
                        if (reader.IsStartElement("PlayerHealth"))
                        {
                            result.PlayerHealth = Convert.ToInt32(reader.GetAttribute("value"));
                        }
                        if (reader.IsStartElement("PlayerSpeed"))
                        {
                            result.PlayerSpeed = Convert.ToSingle(reader.GetAttribute("value"));
                        }
                        if (reader.IsStartElement("PlayerDead"))
                        {
                            result.PlayerDead = Convert.ToBoolean(reader.GetAttribute("value"));
                        }
                        if (reader.IsStartElement("PlayerPosition"))
                        {
                            result.PlayerPosition.X = Convert.ToSingle(reader.GetAttribute("Xvalue"));
                            result.PlayerPosition.Y = Convert.ToSingle(reader.GetAttribute("Yvalue"));
                            result.PlayerPosition.Z = Convert.ToSingle(reader.GetAttribute("Zvalue"));
                        }
                    }
                }
                return (TType)Convert.ChangeType(result, typeof(TType));
            }

            else if(_savedStruct is BonusData)
            {
                BonusData result = new();

                using (XmlTextReader reader = new(SavePath))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement("BonusName"))
                        {
                            result.BonusName = reader.GetAttribute("value");
                        }
                        if (reader.IsStartElement("BonusInteractive"))
                        {
                            result.BonusInteractive = Convert.ToBoolean(reader.GetAttribute("value"));
                        }
                        if (reader.IsStartElement("BonusPosition"))
                        {
                            result.BonusPosition.X = Convert.ToSingle(reader.GetAttribute("Xvalue"));
                            result.BonusPosition.Y = Convert.ToSingle(reader.GetAttribute("Yvalue"));
                            result.BonusPosition.Z = Convert.ToSingle(reader.GetAttribute("Zvalue"));
                        }
                    }
                }
                return (TType)Convert.ChangeType(result, typeof(TType));
            }

            else
            {
                Debug.Log("No known structure to load!");
                return new();
            }
        }
    }
}

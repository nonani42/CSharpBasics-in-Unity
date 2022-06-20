using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Ballgame
{
    [CustomEditor(typeof(Waypoints))]
    public class SaveWaypoints : Editor
    {
        private static XmlSerializer serializer;
        public List<SVect3> SavingNodes = new();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            Waypoints Base = (Waypoints)target;

            if(serializer == null)
            {
                serializer = new(typeof(SVect3[]));
            }
            if (GUILayout.Button("Save Waypoints"))
            {
                if (Base.bonus.Count > 0)
                {
                    foreach (Transform item in Base.bonus)
                    {
                        if (!SavingNodes.Contains(item.position))
                        {
                            SavingNodes.Add(item.position);
                        }
                    }
                }
                using (FileStream fs = new(Base.SavingPath, FileMode.Create))
                {
                    serializer.Serialize(fs, SavingNodes.ToArray());
                }
            }
        }
    }
}

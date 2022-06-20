using System.IO;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
namespace Ballgame
{
    public class Waypoints : MonoBehaviour
    {
        public List<Transform> bonus = new();

        //Saving path
        public string directoryName;
        private string projectPath;
        private string savingPath;
        public string sceneName;

        public string SavingPath { get => savingPath; set => savingPath = value; }
        public string ProjectPath { get => projectPath; set => projectPath = value; }

        private void OnDrawGizmos()
        {
            sceneName = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene().name;
            directoryName = "WaypointData";
            ProjectPath = "/" + directoryName + "/BonusMap_" + sceneName + ".xml";
            SavingPath = Path.Combine(Application.dataPath + ProjectPath);
        }
    }
}
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem {
    public class SaveData : MonoBehaviour
    {
        public int levelSceneIndex;
        public Dictionary<int, SavableData> objectsData;

        public SaveData() {
            levelSceneIndex = 1;
            objectsData = new Dictionary<int, SavableData>();
        }
    }
}
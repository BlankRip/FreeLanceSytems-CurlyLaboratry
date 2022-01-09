using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem {
    [System.Serializable]
    public class SaveData
    {
        public int levelSceneIndex;
        public List<int> ids;
        public List<string> objectDatas;

        public SaveData() {
            levelSceneIndex = 1;
            ids = new List<int>();
            objectDatas = new List<string>();
        }
    }
}
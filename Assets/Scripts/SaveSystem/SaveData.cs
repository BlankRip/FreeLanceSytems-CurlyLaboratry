using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem {
    [System.Serializable]
    public class SaveData : MonoBehaviour
    {
        public int levelSceneIndex;
        public List<int> ids;
        public List<object> objectDatas;

        public SaveData() {
            levelSceneIndex = 1;
            ids = new List<int>();
            objectDatas = new List<object>();
        }
    }
}
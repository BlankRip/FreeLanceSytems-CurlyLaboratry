using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaveSystem {
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager instance;

        private int currentSaveSlot;
        private Dictionary<int, ISavable> savables;

        private void Awake() {
            if(instance == null) {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
                Destroy(this.gameObject);
        }

        public void SetuUpSaveSystem() {
            savables = new Dictionary<int, ISavable>();
            savables.Clear();
        }

        public void SetSaveSlot(int slot) {
            currentSaveSlot = slot;
        }

        public void AddSavable(ISavable item) {
            int itemId = item.GetItemId();
            if(savables.ContainsKey(itemId)) {
                Debug.LogError($"Another savable item has the same id: {itemId}", item.GetGameObject());
                return;
            }
            savables.Add(itemId, item);
        }

        public void Save() {

        }

        private SaveData GetDataToSave() {
            SaveData data = new SaveData();
            data.levelSceneIndex = SceneManager.GetActiveScene().buildIndex;
            foreach (KeyValuePair<int, ISavable> item in savables)
                data.objectsData.Add(item.Value.GetItemId(), item.Value.GetDataToSave());
            return data;
        }
    }
}
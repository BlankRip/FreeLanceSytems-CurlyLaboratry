using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaveSystem {
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager instance;

        [SerializeField] string loadingScreenTag = "LoadingScreen";
        private int currentSaveSlot;
        private SaveData currentData;
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
            StartCoroutine(LoadInAFew());
        }

        private IEnumerator LoadInAFew() {
            GameObject loadingScreen = GameObject.FindGameObjectWithTag(loadingScreenTag);
            yield return new WaitForSeconds(0.4f);
            Load();
            loadingScreen.SetActive(false);
        }
        
        private void Load() {
            SaveData currentData = JsonReadWrite.ReadFromFile(currentSaveSlot);
            if(currentData == null)
                return;
            if(currentData.levelSceneIndex == SceneManager.GetActiveScene().buildIndex) {
                foreach (KeyValuePair<int, ISavable> item in savables)
                    item.Value.Load(currentData.objectDatas[currentData.ids.IndexOf(item.Value.GetItemId())]);
                Debug.Log("Loaded Game");
            } else
                Save();
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
            JsonReadWrite.WriteToFile(GetDataToSave(), currentSaveSlot);
            Debug.Log("Saved Game");
        }

        private SaveData GetDataToSave() {
            SaveData data = new SaveData();
            data.levelSceneIndex = SceneManager.GetActiveScene().buildIndex;
            foreach (KeyValuePair<int, ISavable> item in savables) {
                data.ids.Add(item.Value.GetItemId());
                data.objectDatas.Add(item.Value.GetDataToSave());
            }
            return data;
        }

        public int GetLoadSceneIndex() {
            SaveData currentData = JsonReadWrite.ReadFromFile(currentSaveSlot);
            if(currentData == null)
                return -1;
            else
                return currentData.levelSceneIndex;
        }

        public void ClearSlot() {
            JsonReadWrite.DeleteFile(currentSaveSlot);
        }
    }
}
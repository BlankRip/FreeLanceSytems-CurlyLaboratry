using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SaveSystem;

namespace JustTesting {
    public class TestLightMeter : MonoBehaviour, ISavable
    {
        private Image testImg;

        [Header("Saving related things")]
        [SerializeField] int objectId;

        private void Start() {
            SaveManager.instance.AddSavable(this);
            testImg = GetComponent<Image>();
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.E))
                testImg.fillAmount += .1f;
            else if(Input.GetKeyDown(KeyCode.Q))
                testImg.fillAmount -= .1f;
        }

        public string GetDataToSave() {
            string dataToSend = JsonUtility.ToJson(new MySaveData(testImg.fillAmount));
            return dataToSend;
        }

        public void Load(string recievedData) {
            MySaveData data = JsonUtility.FromJson<MySaveData>(recievedData);
            testImg.fillAmount = data.fillAmount;
        }

        public int GetItemId() {
            return objectId;
        }

        public GameObject GetGameObject() {
            return this.gameObject;
        }

        [System.Serializable]
        private class MySaveData {
            public float fillAmount;

            public MySaveData(float fillAmount) {
                this.fillAmount = fillAmount;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SaveSystem;

namespace JustTesting {
    public class TestEnemy : MonoBehaviour, ISavable
    {
        [SerializeField] float speed;
        [SerializeField] float flipAfter;
        private Vector3 refPoint;

        [Header("Saving related things")]
        [SerializeField] int objectId;

        private void Start() {
            refPoint = transform.position;
            SaveManager.instance.AddSavable(this);
        }

        private void Update() {
            if(Vector3.Distance(refPoint, transform.position) >= flipAfter) {
                refPoint = transform.position;
                speed *= -1;
            }
            Vector3 moveTo = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            transform.position = moveTo;
            transform.Rotate(0, 3, 0);
        }

        public string GetDataToSave() {
            MySaveData dataToSend = new MySaveData(transform.position, refPoint, speed);
            return JsonUtility.ToJson(dataToSend);
        }

        public void Load(string recievedData) {
            MySaveData data = JsonUtility.FromJson<MySaveData>(recievedData);
            speed = data.speed;
            transform.position = data.position;
            refPoint = data.referencePoint;
        }

        public int GetItemId() {
            return objectId;
        }

        public GameObject GetGameObject() {
            return this.gameObject;
        }

        [System.Serializable]
        private class MySaveData {
            public Vector3 position;
            public Vector3 referencePoint;
            public float speed;

            public MySaveData(Vector3 position, Vector3 refPoint, float speed) {
                this.position = position;
                this.referencePoint = refPoint;
                this.speed = speed;
            }
        }
    }
}
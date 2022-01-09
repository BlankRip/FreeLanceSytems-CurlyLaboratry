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

        [Header("Saving related things")]
        [SerializeField] int objectId;

        private void Start() {
            SaveManager.instance.AddSavable(this);
            StartCoroutine(FlipMove());
        }

        private void Update() {
            Vector3 moveTo = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            transform.position = moveTo;
            transform.Rotate(0, 3, 0);
        }

        IEnumerator FlipMove() {
            yield return new WaitForSeconds(flipAfter);
            speed *= -1;
            StartCoroutine(FlipMove());
        }

        public object GetDataToSave() {
            return new MySaveData(transform.position, transform.rotation);
        }

        public void Load(object recievedData) {
            MySaveData data = (MySaveData)recievedData;
            transform.rotation = new Quaternion(data.rotationX, data.rotationY, data.rotationZ, data.rotationW);
            transform.position = new Vector3(data.positionX, data.positionY, data.positionZ);
        }

        public int GetItemId() {
            return objectId;
        }

        public GameObject GetGameObject() {
            return this.gameObject;
        }

        [System.Serializable]
        private class MySaveData {
            public float positionX, positionY, positionZ;
            public float rotationX, rotationY, rotationZ, rotationW;

            public MySaveData(Vector3 position, Quaternion rotation) {
                positionX = position.x;
                positionY = position.y;
                positionZ = position.z;

                rotationX = rotation.x;
                rotationY = rotation.y;
                rotationZ = rotation.z;
                rotationW = rotation.w;
            }
        }
    }
}
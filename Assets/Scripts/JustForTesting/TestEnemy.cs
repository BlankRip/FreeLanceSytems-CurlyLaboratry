using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JustTesting {
    public class TestEnemy : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float flipAfter;

        private void Start() {
            StartCoroutine(FlipMove());
        }

        private void Update() {
            Vector3 moveTo = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            transform.position = moveTo;
        }

        IEnumerator FlipMove() {
            yield return new WaitForSeconds(flipAfter);
            speed *= -1;
            StartCoroutine(FlipMove());
        }
    }
}
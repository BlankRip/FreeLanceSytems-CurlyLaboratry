using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace JustTesting {
    public class GoToNextScreen : MonoBehaviour
    {
        [SerializeField] Button theButton;
        
        private void Start() {
            theButton.onClick.AddListener(() => {SceneManager.LoadScene(1);});
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JustTesting {
    public class TestLightMeter : MonoBehaviour
    {
        private Image testImg;
        
        private void Start() {
            testImg = GetComponent<Image>();
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.E))
                testImg.fillAmount += .1f;
            else if(Input.GetKeyDown(KeyCode.Q))
                testImg.fillAmount -= .1f;
        }
    }
}
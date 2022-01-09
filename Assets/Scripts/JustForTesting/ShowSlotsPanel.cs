using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JustTesting {
    public class ShowSlotsPanel : MonoBehaviour
    {
        [SerializeField] Button theButton;
        [SerializeField] GameObject panelToShow;
        
        private void Start() {
            theButton.onClick.AddListener(() => {panelToShow.SetActive(true);});
        }
    }
}
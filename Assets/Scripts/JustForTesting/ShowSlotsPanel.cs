using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JustTesting {
    public class ShowSlotsPanel : MonoBehaviour
    {
        [SerializeField] Button theButton;
        [SerializeField] GameObject panelToShow;
        [SerializeField] bool showValue;
        
        private void Start() {
            if(theButton == null)
                theButton = GetComponent<Button>();
            theButton.onClick.AddListener(() => {panelToShow.SetActive(showValue);});
        }
    }
}
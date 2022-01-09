using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SaveSystem {
    public class SaveSlotSelector : MonoBehaviour
    {
        [SerializeField] int saveSlotId;
        [SerializeField] Button slotSelectorButton;

        private void Start() {
            if(slotSelectorButton == null)
                slotSelectorButton = GetComponent<Button>();
            slotSelectorButton.onClick.AddListener(() => {SaveManager.instance.SetSaveSlot(saveSlotId);});
        }
    }
}
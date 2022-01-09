using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem {
    public class SaveSystemSetup : MonoBehaviour
    {
        private void Awake() {
            SaveManager.instance.SetuUpSaveSystem();
        }
    }
}
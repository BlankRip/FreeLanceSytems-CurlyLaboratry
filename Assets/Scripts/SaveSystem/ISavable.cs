using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem {
    public interface ISavable
    {
        SavableData GetDataToSave();
        void Load();
        int GetItemId();
        GameObject GetGameObject();
    }
}
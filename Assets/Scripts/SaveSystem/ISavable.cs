using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem {
    public interface ISavable
    {
        SavableData GetDataToSave();
        void Load(SavableData recievedData);
        int GetItemId();
        GameObject GetGameObject();
    }
}
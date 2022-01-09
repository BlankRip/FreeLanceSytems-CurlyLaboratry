using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem {
    public interface ISavable
    {
        string GetDataToSave();
        void Load(string recievedData);
        int GetItemId();
        GameObject GetGameObject();
    }
}
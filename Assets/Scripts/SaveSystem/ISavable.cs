using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem {
    public interface ISavable
    {
        object GetDataToSave();
        void Load(object recievedData);
        int GetItemId();
        GameObject GetGameObject();
    }
}
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SaveSystem {
    public static class JsonReadWrite
    {
        private static string filePath = Application.persistentDataPath;

        public static void WriteToFile(SaveData data, int slotId) {
            string dataToWrite = JsonUtility.ToJson(data);
            string fileName = $"/Save_{slotId}.json";
            File.WriteAllText(filePath + fileName, dataToWrite);
        }

        public static SaveData ReadFromFile(int slotId) {
            string fileName = $"/Save_{slotId}.json";
            Debug.Log(filePath);
            if(File.Exists(filePath + fileName)) {
                string readData = File.ReadAllText(filePath + fileName);
                SaveData recievedData = JsonUtility.FromJson<SaveData>(readData);
                return recievedData;
            } else
                return null;
        }
    }
}
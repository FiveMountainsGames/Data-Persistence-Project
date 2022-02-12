using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

    public string userName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class SaveData
    {
        public string userName;
        public int scores;
    }

    public void SaveRecord(string name, int scores)
    {
        SaveData saveData = new SaveData
        {
            userName = name,
            scores = scores
        };

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
    }

    public SaveData LoadRecord()
    {
        string path = Application.persistentDataPath + "/saveData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            return data;
        }
        SaveData emptyData = new SaveData
        {
            userName = "",
            scores = 0
        };

        return emptyData;

    }
}

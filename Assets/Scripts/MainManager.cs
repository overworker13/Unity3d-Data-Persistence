using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string topPlayerName;
    public int topScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadTopPlayerScore();
    }

    public void SaveTopPlayerScore()
    {
        SaveData data = new SaveData();
        data.topPlayerName = topPlayerName;
        data.topScore = topScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadTopPlayerScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = JsonUtility.ToJson(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            topPlayerName = data.topPlayerName;
            topScore = data.topScore;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string topPlayerName;
        public int topScore;
    }
}

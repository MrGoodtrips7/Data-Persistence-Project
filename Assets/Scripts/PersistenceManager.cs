using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{

    public static PersistenceManager Instance;
    public string PlayerName;
    
    public int HighScore;
    public string HighscoreName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighscore();
    }

    public void SaveHighscore()
    {
        
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.Highscore = HighScore;
        data.HighscoreName = HighscoreName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        
    }
    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.Highscore;
            HighscoreName = data.HighscoreName;
        }
    }
    public string LoadPlayername()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            PlayerName = data.PlayerName;
        }
        return PlayerName;
    }
    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int Highscore;
        public string HighscoreName;
    }
}

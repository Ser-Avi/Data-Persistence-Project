using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    public string playerName;   //name of current player
    public int highScore;       //high score
    public string highName;     //name of high score holder

    //Awake function makes sure this persists between scenes and doesn't duplicate
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    //sets player name, used by input field
    public void SetName(string name)
    {
        playerName = name;
    }

    //save data class to save high score and score holder
    [System.Serializable]
    class SaveData
    {
        public string recordHolder;
        public int recordVal;
    }

    //saves the record score to a JSON file
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.recordHolder = highName;
        data.recordVal = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    //Loads record based on JSON file
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highName = data.recordHolder;
            highScore = data.recordVal;
        }
    }
}

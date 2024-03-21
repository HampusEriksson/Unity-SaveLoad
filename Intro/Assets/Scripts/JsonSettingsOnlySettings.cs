using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonSettingsOnlySettings : MonoBehaviour
{
    private string saveFilePath;
    private GameData gameData;

    private void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");
        InitializeGameData();
        LoadGameData();
    }

    private void InitializeGameData()
    {
        if (!File.Exists(saveFilePath))
        {
            gameData = new GameData();
            SaveSettings();
        }
    }

    public void SaveHighscore(float newTime)
    {
        // TODO: Implement highscore saving logic
        SaveSettings();
    }

    public Dictionary<string, float> GetHighscores()
    {
        return gameData.highScores;
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameData);
        try
        {
            File.WriteAllText(saveFilePath, jsonData);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save settings: " + e.Message);
        }
    }

    public void LoadGameData()
    {
        if (File.Exists(saveFilePath))
        {
            string jsonData = File.ReadAllText(saveFilePath);
            gameData = JsonUtility.FromJson<GameData>(jsonData);
        }
        else
        {
            Debug.LogWarning("No save data found.");
        }
    }
}

[System.Serializable]
public class GameData
{
    public Dictionary<string, float> highScores = new Dictionary<string, float>();
}

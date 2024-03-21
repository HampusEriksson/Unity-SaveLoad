using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonSettings
{
    private static string saveFilePath;
    private static GameData gameData;

    public static void Initialize()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");
        InitializeGameData();
        LoadGameData();
    }

    private static void InitializeGameData()
    {
        if (!File.Exists(saveFilePath))
        {
            gameData = new GameData();
            SaveSettings();
        }
    }

    private static void LoadGameData()
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

    public static string GetUsername()
    {
        return gameData.currentUsername;
    }

    public static void SetUsername(string newUsername)
    {
        gameData.currentUsername = newUsername;
        SaveSettings();
    }

    public static float GetSpeed()
    {
        return gameData.speed;
    }

    public static void SetSpeed(float newSpeed)
    {
        gameData.speed = newSpeed;
        SaveSettings();
    }

    public static string GetColor()
    {
        return gameData.color;
    }

    public static void SetColor(string newColor)
    {
        gameData.color = newColor;
        SaveSettings();
    }

    public static void SaveHighscore(float newTime)
    {
        if (gameData.highScores.ContainsKey(gameData.currentUsername))
        {
            if (newTime < gameData.highScores[gameData.currentUsername])
            {
                gameData.highScores[gameData.currentUsername] = newTime;
            }
        }
        else
        {
            gameData.highScores.Add(gameData.currentUsername, newTime);
        }
        SaveSettings();
    }

    public static Dictionary<string, float> GetHighscores()
    {
        return gameData.highScores;
    }

    public static void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameData);    
        Debug.Log(jsonData);  
        Debug.Log(gameData.highScores[gameData.currentUsername]);
        File.WriteAllText(saveFilePath, jsonData);
        
    }

    
    
}

[System.Serializable]
public class GameData
{
    public string currentUsername = "";
    public float speed = 1;
    public string color = "white";
    public Dictionary<string, float> highScores = new Dictionary<string, float>();
}

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

    public static void SetHighscore(float newTime)
    {
        Highscore newHighscore = new Highscore
        {
            username = gameData.currentUsername,
            time = newTime
        };
        gameData.highscores.Add(newHighscore);
        SaveSettings();
    }

    public static List<Highscore> GetHighscores()
    {
        return gameData.highscores;
    }

    public static void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameData);    
        File.WriteAllText(saveFilePath, jsonData);
        
    }
}

[System.Serializable]
public class GameData
{
    public string currentUsername = "";
    public float speed = 1;
    public string color = "white";
    public List<Highscore> highscores = new List<Highscore>();
}

[System.Serializable]
public class Highscore
{
    public string username;
    public float time;
}
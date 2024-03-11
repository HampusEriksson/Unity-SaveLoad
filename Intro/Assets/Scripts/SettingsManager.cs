using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private string saveFilePath;
    
    public TMP_InputField usernameInput;
    public TextMeshProUGUI usernameDisplay;

    public Slider speedSlider;
    public TextMeshProUGUI speedDisplay;

    private const string usernameKey = "PlayerUsername";
    private const string speedKey = "1";

    private void Start()
    {
        if (PlayerPrefs.HasKey(usernameKey))
        {
            usernameDisplay.text = PlayerPrefs.GetString(usernameKey);
        }
        if (PlayerPrefs.HasKey(speedKey))
        {
            speedSlider.value = PlayerPrefs.GetInt(speedKey);
            UpdateSpeed();
        }
        GameData gameData = LoadGameData();
        if (gameData != null)
        {
            usernameDisplay.text = gameData.username;
            speedSlider.value = gameData.speed;
            UpdateSpeed();
        }
    }


    private void Awake()
    {
        Debug.Log(Application.persistentDataPath);
        saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");
        // Check if file exists, if not create it
        if (!File.Exists(saveFilePath))
        {
            File.Create(saveFilePath).Dispose();
        }
    }

    public void UpdateSpeed()
    {
        speedDisplay.text = speedSlider.value.ToString();
    }

    public void SaveSettings()
    {
        if (usernameInput.text != "")
        {
            PlayerPrefs.SetString(usernameKey, usernameInput.text);
        }
       
        
        PlayerPrefs.SetFloat(speedKey, speedSlider.value);
        GameData gameData = new GameData();
        gameData.username = PlayerPrefs.GetString(usernameKey);
        gameData.speed = (int)PlayerPrefs.GetFloat(speedKey);
        string jsonData = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath, jsonData);
        usernameDisplay.text = PlayerPrefs.GetString(usernameKey);

    }

    public GameData LoadGameData()
    {
        if (File.Exists(saveFilePath))
        {
            string jsonData = File.ReadAllText(saveFilePath);
            return JsonUtility.FromJson<GameData>(jsonData);
        }
        else
        {
            Debug.LogWarning("Save file not found.");
            return null;
        }
    }
}

[System.Serializable]
public class GameData
{
    
    public string username;
    public int speed;
}


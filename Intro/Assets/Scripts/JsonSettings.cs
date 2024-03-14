using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class JsonSettings : MonoBehaviour
{
    private string saveFilePath;
    
    public TMP_InputField usernameInput;
    public TextMeshProUGUI usernameDisplay;

    public Slider speedSlider;
    public TextMeshProUGUI speedDisplay;

    GameData gameData;

    private void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");

       
        LoadGameData();

        usernameDisplay.text = gameData.username;
        speedSlider.value = gameData.speed;
        UpdateSpeed();
        
    }

    public void UpdateSpeed()
    {
        speedDisplay.text = speedSlider.value.ToString();
        gameData.speed = (int)speedSlider.value;
    }

    public void UpdateUsername(){
        gameData.username = usernameInput.text;
        usernameDisplay.text = usernameInput.text;
    }

    public void SaveSettings()
    { 
        string jsonData = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath, jsonData);
    }

    public void LoadGameData()
    {
        if (File.Exists(saveFilePath))
        {
            string jsonData = File.ReadAllText(saveFilePath);
            gameData =  JsonUtility.FromJson<GameData>(jsonData);
        }
        else
        {
            File.Create(saveFilePath).Dispose();
            gameData = new GameData();
            string jsonData = JsonUtility.ToJson(gameData);
            File.WriteAllText(saveFilePath, jsonData);
        }
    }
}

/*
The class is marked with the attribute [System.Serializable], 
which indicates that instances of this class can be serialized and deserialized,
meaning they can be converted into a format that can be stored or transmitted 
and then reconstructed back into an object later.
*/
[System.Serializable]
public class GameData
{
    public string username;
    public int speed;
    public string[] inventory;

    public GameData()
   {
      username = "";
      speed = 1;
   }
}


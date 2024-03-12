using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TextMeshProUGUI usernameDisplay;

    public Slider speedSlider;
    public TextMeshProUGUI speedDisplay;
    
    private const string usernameKey = "username";
    private const string speedKey = "1";

    void Start()
    {
        if (PlayerPrefs.HasKey(usernameKey))
        {
            usernameDisplay.text = PlayerPrefs.GetString(usernameKey);
        }
        if (PlayerPrefs.HasKey(speedKey))
        {
            speedSlider.value = PlayerPrefs.GetFloat(speedKey);
            speedDisplay.text = PlayerPrefs.GetFloat(speedKey).ToString();
        }           
    }

    public void UpdateSpeed()
    {
        PlayerPrefs.SetFloat(speedKey, speedSlider.value);
        speedDisplay.text = PlayerPrefs.GetFloat(speedKey).ToString();
    }

    public void UpdateUsername()
    {
        if (usernameInput.text != "")
        {
        PlayerPrefs.SetString(usernameKey, usernameInput.text);
        usernameDisplay.text = PlayerPrefs.GetString(usernameKey);
        }
    }

}

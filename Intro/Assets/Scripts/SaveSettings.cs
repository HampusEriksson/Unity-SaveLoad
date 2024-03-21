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
    

    void Start()
    {
        usernameDisplay.text = PlayerRefsSettings.GetUsername();
        speedSlider.value =  PlayerRefsSettings.GetSpeed();
        speedDisplay.text = speedSlider.value.ToString();
    }

    public void UpdateSpeed()
    {
        PlayerRefsSettings.SetSpeed(speedSlider.value);
        speedDisplay.text = speedSlider.value.ToString();
    }

    public void UpdateUsername()
    {
        if (usernameInput.text != "")
        {
            PlayerRefsSettings.SetUsername(usernameInput.text);
            usernameDisplay.text = PlayerRefsSettings.GetUsername();
        }
    }

}

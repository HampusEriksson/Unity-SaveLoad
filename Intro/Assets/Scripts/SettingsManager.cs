using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class SettingsManager : MonoBehaviour
{

    public TMP_InputField usernameInput;
    public TextMeshProUGUI usernameDisplay;
    public Slider speedSlider;
    public TextMeshProUGUI speedDisplay;
    

    void Start()
    {
        JsonSettings.Initialize();
        JsonSettings.SaveHighscore(5.3f);
        usernameDisplay.text = JsonSettings.GetUsername();
        speedSlider.value =  JsonSettings.GetSpeed();
        speedDisplay.text = speedSlider.value.ToString();
    }

    public void UpdateSpeed()
    {
        JsonSettings.SetSpeed(speedSlider.value);
        speedDisplay.text = speedSlider.value.ToString();
    }

    public void UpdateUsername()
    {
        if (usernameInput.text != "")
        {
            JsonSettings.SetUsername(usernameInput.text);
            usernameDisplay.text = JsonSettings.GetUsername();
        }
    }

    
}

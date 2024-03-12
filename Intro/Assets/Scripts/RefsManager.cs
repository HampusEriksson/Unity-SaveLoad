using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class RefsManager : MonoBehaviour
{
    private const string usernameKey = "PlayerUsername";
    private const string speedKey = "1";

    public void UpdateSpeed()
    {
        
        //PlayerPrefs.SetFloat(speedKey, speedSlider.value);
    }

    public void UpdateUsername(string newUsername)
    {
        if (newUsername != "")
        {
            PlayerPrefs.SetString(usernameKey, newUsername);
        }
       
  
    }

    
}



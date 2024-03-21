using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRefsSettings
{
    private const string usernameKey = "";
    private const string speedKey = "1";

    public static string GetUsername()
    {
        return PlayerPrefs.GetString(usernameKey, "");
    }

    public static float GetSpeed()
    {
        return PlayerPrefs.GetFloat(speedKey, 1.0f);
    }

    public static void SetSpeed(float newSpeed)
    {
        PlayerPrefs.SetFloat(speedKey, newSpeed);
    }

    public static void SetUsername(string newUsername)
    {
        if (newUsername != "")
        {
            PlayerPrefs.SetString(usernameKey, newUsername);
        }
    }
}

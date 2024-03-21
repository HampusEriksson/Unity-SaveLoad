using UnityEngine;

public class SaveInfo : MonoBehaviour
{
    private const string usernameKey = "PlayerUsername";
    private const string speedKey = "1";

    public static string GetUsername()
    {
        return PlayerPrefs.GetString(usernameKey, "Player");
    }

    public static void SetUsername(string newUsername)
    {
        if (newUsername != "")
        {
            PlayerPrefs.SetString(usernameKey, newUsername);
        }
    }

    public static float GetSpeed()
    {
        return PlayerPrefs.GetFloat(speedKey, 1);
    }

    public static void SetSpeed(float newSpeed)
    {
        PlayerPrefs.SetFloat(speedKey, newSpeed);
    }
}

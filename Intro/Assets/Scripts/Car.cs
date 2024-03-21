
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    private string name;
    
    void Start(){
        name = SaveInfo.GetUsername();
    }

    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public MagnetField magnetField;
    
    public void Interact()
    {
        if (magnetField != null)
        {
            magnetField.ToggleMagneticField(); //С помощью ключа меняем значемние isActive
        }
    }
}

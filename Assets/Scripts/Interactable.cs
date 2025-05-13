using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact() //Просто пишем с кем взаимодействуем
    {
        Debug.Log("Взаимодействие с " + gameObject.name);
    }
}

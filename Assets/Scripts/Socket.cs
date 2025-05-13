using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public string acceptedTag = "Screw"; //На какой тег реагируем
    public Vector3 insertOffset = new Vector3(0, 0.03f, 0); //Настройка координат относительно объекта Socet
    
    public bool TryInsert(Grabbable grabbable)
    {
        if (grabbable.CompareTag(acceptedTag))//Если тег болта есть, то выполняем функцию и выходим из неё (иначе ничего не делаем и также выходим)
        {
            grabbable.transform.SetParent(transform);
            grabbable.transform.localPosition = insertOffset;
            grabbable.transform.localRotation = Quaternion.identity;
            
            Rigidbody rb = grabbable.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
            
            return true;
        }
        return false;
    }
}

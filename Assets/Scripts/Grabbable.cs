using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }
    
    public void Grab(Transform holder)
    {
        rb.isKinematic = true;
        rb.useGravity = false;
        col.enabled = false;
        transform.SetParent(holder);
    }
    
    public void Drop()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        col.enabled = true;
        transform.SetParent(null);
    }
}

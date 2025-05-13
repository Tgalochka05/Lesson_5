using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Radio : Interactable
{
    private AudioSource audioSource;
    private bool isPlaying = false; //Изначально радио выключено
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; //Музыка будет играть бесконечно
    }
    
    public override void Interact() //Отключаем или включаем музыку
    {
        if (isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
        isPlaying = !isPlaying;
    }
}

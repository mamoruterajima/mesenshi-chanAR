using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Voice : MonoBehaviour
{
    int i = 0;
    public AudioClip[] sound;
    AudioSource audioSource;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            i++;
            audioSource.PlayOneShot(sound[i]);
                
        }
        
    }
}

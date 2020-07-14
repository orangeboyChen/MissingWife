using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSFX : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip open, close, shut;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void Open()
    {
        audioSource.clip = open;
        audioSource.Play();
    }
    public void Close()
    {
        audioSource.clip = close;
        audioSource.Play();
    }
    public void Shut()
    {
        audioSource.clip = shut;
        audioSource.Play();
    }
}

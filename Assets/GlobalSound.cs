using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSound : MonoBehaviour
{
    public AudioClip livingRoomAmbient;
    private AudioSource audioSo;
    public AudioClip[] stepsOnFloor;
    public AudioClip[] stepsInToilet;


    // public AudioClip 
    private void Start()
    {
        audioSo = GetComponent<AudioSource>();
    }
}

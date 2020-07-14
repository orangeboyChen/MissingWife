using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    public GameObject[] lightsToSwitch;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void Interact()
    {
        foreach(var item in lightsToSwitch)
        {
            item.SetActive(!item.activeSelf);
        }
        audioSource.Play();
    }
}

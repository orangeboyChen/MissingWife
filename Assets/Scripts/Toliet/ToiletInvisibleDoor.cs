using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletInvisibleDoor : MonoBehaviour
{
    private bool status = false;

    private Animation animation;

    public String animationName = "InvisibleDoor";

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        Close();
    }

    public void OnInteract()
    {

    }

    public void Open()
    {
        status = true;
        animation[animationName].speed = 1;
        animation.Play(animationName);
    }

    public void Close()
    {
        status = false;
        animation[animationName].speed = -1;
        animation[animationName].time = animation[animationName].length;
        animation.Play(animationName);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("2333"))
        {
            Open();
        }
    }

    private void OnMouseDown()
    {
        Open();
    }




}

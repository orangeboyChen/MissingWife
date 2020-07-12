using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletInvisibleDoor : MonoBehaviour
{
    private bool status = false;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open()
    {
        //片段
        AnimatorClipInfo[] temps = animator.GetCurrentAnimatorClipInfo(0);
        AnimatorClipInfo clipInfo = new AnimatorClipInfo();
        if (temps.Length > 0)
        {
            clipInfo = temps[0];
        }

        //设置、播放动画
        animator.enabled = true;
        animator.StartPlayback();
        animator.speed = -1;
        animator.Play(clipInfo.clip.name, 0, 1);

        //改变状态
        status = true;

    }

    public void Close()
    {
        //片段
        AnimatorClipInfo[] temps = animator.GetCurrentAnimatorClipInfo(0);
        AnimatorClipInfo clipInfo = new AnimatorClipInfo();
        if (temps.Length > 0)
        {
            clipInfo = temps[0];
        }

        //设置、播放动画
        animator.StopPlayback();
        animator.enabled = true;
        animator.speed = 1;
        animator.Play(clipInfo.clip.name);

        //改变状态
        status = false;

    }

    private void OnGUI()
    {
        if (GUILayout.Button("开隐藏门"))
        {
            Open();
        }
        else if (GUILayout.Button("关隐藏门"))
        {
            Close();
        }
    }





}

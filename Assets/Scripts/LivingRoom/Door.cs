using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /// <summary>
    /// 灵敏度
    /// </summary>
    private const float SENSITIVITY = 3f;

    /// <summary>
    /// 门是否已经开启
    /// </summary>
    private bool doorStatus = false;


    /// <summary>
    /// 动画小助手
    /// </summary>
    private Animator animator = null;

    /// <summary>
    /// 相机组件
    /// </summary>
    private Camera camera = null;

    public GameObject livingRoomDoorTip;
    public GameObject toiletDoorTip;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("f"))
        {
            //计算距离
            if ((this.transform.position - camera.transform.position).sqrMagnitude > SENSITIVITY) return;
            OpenOrClose();
        }

        //提示是否可见
        bool isTipVisible = ((this.transform.position - camera.transform.position).sqrMagnitude < SENSITIVITY) && !doorStatus;
        livingRoomDoorTip.SetActive(isTipVisible);
        toiletDoorTip.SetActive(isTipVisible);
    }

    /// <summary>
    /// 开门
    /// </summary>
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
        doorStatus = true;


    }

    /// <summary>
    /// 关门
    /// </summary>
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
        doorStatus = false;


    }

    /// <summary>
    /// 根据门的状态自动开门或关门
    /// </summary>
    public void OpenOrClose()
    {
        if (doorStatus)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cc;
    public GameObject fpsCam;
    public float mouseSensitivity;
    private float vx, vy,mx,my;
    public float moveSpeed;
    private float XRotation;
    public Animator anim;
    private Vector3 velocity;
    
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the player
        vx = Input.GetAxisRaw("Horizontal");
        vy = Input.GetAxisRaw("Vertical");
        Vector3 dir = (transform.forward * vy + transform.right * vx).normalized;
        Vector3 movement = dir * moveSpeed * Time.deltaTime;
        if(dir.magnitude > .1f) anim.SetBool("walking", true);
        else anim.SetBool("walking", false);
        cc.Move(movement);
        
        //add  gravity
        if (cc.isGrounded) velocity.y = -2f;
        else velocity.y += Physics.gravity.y * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);



            //move the camera
        mx = Input.GetAxis("Mouse X");
        my = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up * mx * mouseSensitivity * Time.deltaTime);
        
        XRotation -= my * mouseSensitivity * Time.deltaTime;
        XRotation = Mathf.Clamp(XRotation, -89f, 89f);
        
        fpsCam.transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        
        
    }
    
}

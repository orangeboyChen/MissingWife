using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public Animator anim;
    

    public override void Interact()
    {
        anim.SetBool("isOpen", !anim.GetBool("isOpen"));
    }

    // Start is called before the first frame update
    void Start()
    {
        setDoor(false);
    }

    void setDoor(bool flag)
    {
        anim.SetBool("isOpen", flag);
    }
}

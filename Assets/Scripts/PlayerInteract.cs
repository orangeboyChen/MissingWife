using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject cam;
    public float interactDis;

    public GameObject interactTip;

    private void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.red);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactDis) && hit.transform.GetComponent<Interactable>() != null)
        {
            ShowTip(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.transform.GetComponent<Interactable>().Interact();
            }
            Debug.Log("can interact");
        }
        else
        {
            ShowTip(false);
        }
    }

    public void ShowTip(bool flag)
    {
        interactTip.SetActive(flag);
    }
}

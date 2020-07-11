using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class LivingRoomLightSwitch : MonoBehaviour
{
    /**
     * 灯是否打开
     */
    bool isLightOpened = true;

    /**
    * 所有灯光组件
    */
    private GameObject[] lights = null;

    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("LivingRoomLights");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        OnInteract();
    }

    public void OnInteract()
    {
        if (lights == null) return;
        foreach (GameObject light in lights)
        {
            Light lightComponent = light.GetComponent<Light>();
            lightComponent.enabled = !isLightOpened;
        }
        isLightOpened = !isLightOpened;
    }
}

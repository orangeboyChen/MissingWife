using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletLightSwitch : MonoBehaviour
{
    /// <summary>
    /// 灵敏度
    /// </summary>
    private const float SENSITIVITY = 1.5f;

    /// <summary>
    /// 灯是否打开
    /// </summary>
    bool isLightOpened = true;

    /// <summary>
    /// 所有灯光组件
    /// </summary>
    private GameObject[] lights = null;

    /// <summary>
    /// 相机组件
    /// </summary>
    private Camera camera = null;


    // Start is called before the first frame update
    void Start()
    {
        //初始化组件
        lights = GameObject.FindGameObjectsWithTag("ToiletLights");
        camera = GameObject.FindObjectOfType<Camera>();

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

        //计算距离
        if ((this.transform.position - camera.transform.position).sqrMagnitude > SENSITIVITY) return;

        foreach (GameObject light in lights)
        {
            Light lightComponent = light.GetComponent<Light>();
            lightComponent.enabled = !isLightOpened;
        }
        isLightOpened = !isLightOpened;
    }


}

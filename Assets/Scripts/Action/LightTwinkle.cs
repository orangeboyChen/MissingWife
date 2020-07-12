using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LightTwinkle : MonoBehaviour
{
    /// <summary>
    /// 是否闪烁
    /// </summary>
    public static bool isTwinkling = true;

    /// <summary>
    /// 是否打开蹦迪灯效
    /// </summary>
    public static bool isDiscoColor = false;

    /// <summary>
    /// 灯光最大亮度
    /// </summary>
    public float lightMaxIntensity;

    /// <summary>
    /// 灯光最小亮度
    /// </summary>
    public float lightMinIntensity = 5;

    /// <summary>
    /// 灯光闪烁步长
    /// </summary>
    public float lightStep = 5;

    /// <summary>
    /// 灯光闪烁间隔
    /// </summary>
    public float lightTwinklingTime = 0.02f;

    /// <summary>
    /// 累计时间
    /// </summary>
    private float time = 0;

    /// <summary>
    /// 洗手间灯光组
    /// </summary>
    GameObject[] toiletLights = null;

    /// <summary>
    /// 客厅灯光组
    /// </summary>
    GameObject[] livingRoomLights = null;

    /// <summary>
    /// 灯光缓存
    /// </summary>
    bool temp;


    //Color toiletLightColor;
    //Color livingRoomLightColor;
    private Color initColor;

    // Start is called before the first frame update
    void Start()
    {
        //初始化
        //toiletLights = GameObject.FindGameObjectsWithTag("ToiletLights");
        //livingRoomLights = GameObject.FindGameObjectsWithTag("LivingRoomLights");

        //toiletLightColor = toiletLights[0].GetComponent<Light>().color;
        //livingRoomLightColor = livingRoomLights[0].GetComponent<Light>().color;
        initColor = GetComponent<Light>().color;
        lightMaxIntensity = GetComponent<Light>().intensity;
        lightStep = (lightMaxIntensity - lightMinIntensity) / 16f;
    }

    
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (isTwinkling && time > lightTwinklingTime)
        {
            HandleLightIntensity();
            time = 0f;
        }

    }

    /// <summary>
    /// 控制灯光闪烁的方法
    /// </summary>
    /// <param name="gameObjects">灯光游戏对象数组</param>
    /// <param name="temps">缓存数组，存该越来越亮还是越来越暗</param>
    public void HandleLightIntensity()
    {
        Light lightComponent = this.GetComponent<Light>();

        if (lightComponent.intensity > lightMinIntensity && lightComponent.intensity < lightMaxIntensity)
        {

            if (!temp)
            {
                //越来越暗
                lightComponent.intensity -= lightStep;
            }
            else
            {
                //越来越亮
                lightComponent.intensity += lightStep;
            }
        }
        else
        {
            if (isDiscoColor)
            {
                //随机颜色
                lightComponent.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
            }

            //灯光达到最亮或最暗
            if (lightComponent.intensity <= lightMinIntensity)
            {
                temp = true;
                lightComponent.intensity = lightMinIntensity + 1;
            }
            else if (lightComponent.intensity >= lightMaxIntensity)
            {
                temp = false;
                lightComponent.intensity = lightMaxIntensity - 1;
            }

        }
    }

    /// <summary>
    /// 给所有灯光随机的颜色
    /// </summary>
    /// <param name="gameObjects"></param>
    private void ChangeLightRandomColor(GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Light lightComponent = gameObjects[i].GetComponent<Light>();
            lightComponent.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }

    }

    /// <summary>
    /// 初始化灯光组
    /// </summary>
    public void init()
    {
        //foreach(GameObject light in toiletLights)
        //{
        //    light.GetComponent<Light>().intensity = lightMaxIntensity;
        //    light.GetComponent<Light>().color = toiletLightColor;
        //}

        //foreach (GameObject light in livingRoomLights)
        //{
        //    light.GetComponent<Light>().intensity = lightMaxIntensity;
        //    light.GetComponent<Light>().color = livingRoomLightColor;
        //}
        this.GetComponent<Light>().intensity = lightMaxIntensity;
        this.GetComponent<Light>().color = initColor;

        time = 0;
        temp = true;

    }


    /// <summary>
    /// 设置是否闪烁
    /// </summary>
    /// <param name="b"></param>
    public void setTwinkle(bool b)
    {
        isTwinkling = b;
        this.GetComponent<Light>().intensity = lightMaxIntensity;
    }

    /// <summary>
    /// 设置是否打开蹦迪灯光
    /// </summary>
    /// <param name="b"></param>
    public void setDiscoColor(bool b)
    {
        isDiscoColor = b;
        this.GetComponent<Light>().color = initColor;

    }

    private void OnGUI()
    {
        if (GUILayout.Button("twinkle"))
        {
            setTwinkle(!isTwinkling);
        }
        else if (GUILayout.Button("disco"))
        {
            setDiscoColor(!isDiscoColor);
        }
    }



}

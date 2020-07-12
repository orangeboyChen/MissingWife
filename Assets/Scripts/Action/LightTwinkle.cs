using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTwinkle : MonoBehaviour
{
    private bool isTwinkle = true;
    private bool isStrangeColor = false;
    private const int LIGHT_INTENSITY = 70;
    private float time = 0;
    GameObject[] toiletLights = null;
    GameObject[] livingRoomLights = null;

    bool[] toiletLightsTemp;
    bool[] livingLightsTemp;
    // Start is called before the first frame update
    void Start()
    {
        toiletLights = GameObject.FindGameObjectsWithTag("ToiletLights");
        livingRoomLights = GameObject.FindGameObjectsWithTag("LivingRoomLights");

        toiletLightsTemp = new bool[toiletLights.Length];
        livingLightsTemp = new bool[livingRoomLights.Length];

        initBoolArray(toiletLightsTemp, true);
        initBoolArray(livingLightsTemp, true);  
    }

    
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (isTwinkle && time > 0.02f)
        {
            HandleLightIntensity(toiletLights, toiletLightsTemp);
            HandleLightIntensity(livingRoomLights, livingLightsTemp);

            time = 0f;
        }

    }

    public void HandleLightIntensity(GameObject[] gameObjects, bool[] temps)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Light lightComponent = gameObjects[i].GetComponent<Light>();

            if (lightComponent.intensity > 5 && lightComponent.intensity < LIGHT_INTENSITY )
            {

                if (!temps[i])
                {
                    lightComponent.intensity -= 5;
                    print("d " + lightComponent.intensity);

                }
                else
                {
                    lightComponent.intensity += 5;
                    print("i " + lightComponent.intensity);

                }
            }
            else
            {
                if (isStrangeColor)
                {
                    lightComponent.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
                }
                if (lightComponent.intensity <= 5)
                {
                    temps[i] = true;
                    lightComponent.intensity = 5 + 1;
                }
                if (lightComponent.intensity >= LIGHT_INTENSITY)
                {
                    temps[i] = false;
                    lightComponent.intensity = LIGHT_INTENSITY - 1;
                }

            }
        }
    }

    public void ChangeLightRandomColor(GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Light lightComponent = gameObjects[i].GetComponent<Light>();
            lightComponent.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }

    }

    public void initLight(GameObject[] gameObjects)
    {
        foreach(GameObject light in gameObjects)
        {
            light.GetComponent<Light>().intensity = LIGHT_INTENSITY;
        }
        isTwinkle = false;
        time = 0;
        initBoolArray(toiletLightsTemp, true);
        initBoolArray(livingLightsTemp, true);

    }

    public void initBoolArray(bool[] array, bool b)
    {
        for(int i = 0; i < array.Length; i++)
        {
            array[i] = b;
        }
    }


}

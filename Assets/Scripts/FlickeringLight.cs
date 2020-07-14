using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private bool isFlicering = false;
    public float timeDelay;
    private Light light;
    private void Start()
    {
        light = GetComponent<Light>();
    }
    void Update()
    {
        if (!isFlicering) StartCoroutine("Flickering");
    }

    private IEnumerator Flickering()
    {
        isFlicering = true;
        light.enabled = true;
        yield return new WaitForSeconds(Random.Range(0f, timeDelay));
        light.enabled = false;
        yield return new WaitForSeconds(Random.Range(0f, timeDelay));
        isFlicering = false;
    }
}

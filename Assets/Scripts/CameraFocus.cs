using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class CameraFocus : MonoBehaviour
{
    Ray raycast;
    RaycastHit hit;
    bool isHit;
    float hitDistance;

    public Volume volume;
    DepthOfField depthOfField;
    public float focusSpeed;
    public float offset;

    private void Start()
    {
        volume.profile.TryGet(out depthOfField);
    }
    void Update()
    {
        raycast = new Ray(transform.position, transform.forward * 100f);
        isHit = false;
        if(Physics.Raycast(raycast, out hit, 100f))
        {
            isHit = true;
            hitDistance = hit.distance + offset;
            Debug.Log("Hit" + hit.transform.name);
        }
        else
        {
            if (hitDistance < 100f) hitDistance++;
        }
        SetFocus();
    }

    void SetFocus()
    {
        depthOfField.focusDistance.value = Mathf.Lerp(depthOfField.focusDistance.value, hitDistance, Time.deltaTime * focusSpeed);
    }

    private void OnDrawGizmos()
    {
        if (isHit)
        {
            Gizmos.DrawSphere(hit.point, .1f);
            Gizmos.DrawRay(transform.position, transform.forward * hitDistance);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * 100f);
        }
    }
}

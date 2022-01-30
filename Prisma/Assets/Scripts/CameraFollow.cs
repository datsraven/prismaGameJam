using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Target;
    public float InterpFactor = 5f;

    public Vector2 XLimits;
    public Vector2 YLimits;
 

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.transform.position, Mathf.Clamp01(InterpFactor * Time.deltaTime));
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, XLimits.x, XLimits.y),
            Mathf.Clamp(transform.position.y, YLimits.x, YLimits.y),
            -10);
    }
}

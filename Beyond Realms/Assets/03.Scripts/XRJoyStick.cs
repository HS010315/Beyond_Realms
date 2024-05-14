using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRJoyStick : MonoBehaviour
{
    public Transform topOfJoyStick;

    [SerializeField]
    private float forwardBackwardTilt = 0;
    [SerializeField]
    private float sideTosideTilt = 0;

    // Update is called once per frame
    void Update()
    {
        forwardBackwardTilt = topOfJoyStick.rotation.eulerAngles.x;
        if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
        {
            forwardBackwardTilt = Mathf.Abs(forwardBackwardTilt - 360);
        }
        sideTosideTilt = topOfJoyStick.rotation.eulerAngles.z;
        if (sideTosideTilt < 355 && sideTosideTilt > 290)
        {
            sideTosideTilt = Mathf.Abs(sideTosideTilt - 360);
        }
    }
}

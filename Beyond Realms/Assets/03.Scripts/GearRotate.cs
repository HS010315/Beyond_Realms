using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GearRotate : MonoBehaviour
{
    public Transform rotateGear;
    public Transform reverseGear;
    public Transform[] smallRotateGear;
    public Transform[] smallReverseGear;

    public bool rotatedFinish = false;

    public UnityEvent gearRotated;
    void Update()
    {
        float currentRotationZ = transform.rotation.eulerAngles.z;

        if (!rotatedFinish && Mathf.Approximately(currentRotationZ, 180f))
        {
            gearRotated.Invoke();
            rotatedFinish = true;
        }

        Quaternion newRotation = Quaternion.Euler(0, 0, currentRotationZ);
        Quaternion reverseRotation = Quaternion.Euler(0, 0, -currentRotationZ);
        Quaternion smallRotation = Quaternion.Euler(0, 0, currentRotationZ / 2);
        Quaternion smallReverseRotation = Quaternion.Euler(0, 0, -currentRotationZ / 2);

        rotateGear.rotation = newRotation;
        reverseGear.rotation = reverseRotation;
        foreach(var srgs1 in smallRotateGear)
        {
            srgs1.rotation = smallRotation;
        }
        foreach(var srgs2 in smallReverseGear)
        {
            srgs2.rotation = smallReverseRotation;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightVisionToggle : MonoBehaviour
{
    public Transform headPosition;
    public Transform leftHand;
    public Transform rightHand;
    public float activationDistance = 0.05f;
    public GameObject visionObject;
    private bool visionActivated = false;
    private float testtime = 0f;
    void Start()
    {
        visionObject.SetActive(false);
        visionActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(leftHand.position, rightHand.position) < activationDistance ||
            Vector3.Distance(rightHand.position, headPosition.position) < activationDistance )
        {
            testtime += Time.deltaTime;
            if(3 <= testtime && visionActivated == false)
            {
                testtime = 0;
                ActivateVision();
            }
            else if(3 <= testtime && visionActivated ==true)
            {
                testtime = 0;
                DeactivateVision();
            }
        }
        else
        {
            testtime = 0;
        }
    }

    void ActivateVision()
    {
        visionObject.SetActive(true);
        visionActivated = true;
    }

    void DeactivateVision()
    {
        visionObject.SetActive(false);
        visionActivated = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightVisionToggle : MonoBehaviour
{
    public Transform headPosition;
    public Transform leftHand;
    public Transform rightHand;
    public float activationDistance = 0.05f;
    public GameObject visionObejct;
    private bool visionActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        visionObejct.SetActive(false);
        visionActivated = false;
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(leftHand.position, rightHand.position) < activationDistance && visionActivated == false ||
            Vector3.Distance(rightHand.position, headPosition.position) < activationDistance && visionActivated == false)
        {
            visionObejct.SetActive(true);
            visionActivated = true;
            Debug.Log("Yeah body");
        }
        if (Vector3.Distance(leftHand.position, rightHand.position) < activationDistance && visionActivated == true ||
            Vector3.Distance(rightHand.position, headPosition.position) < activationDistance && visionActivated == true)
        {
            visionObejct.SetActive(false);
            visionActivated = false;
            Debug.Log("Light weight baby");
        }
    }
}

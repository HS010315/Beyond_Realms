using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePuzzle : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        float angleA = NormalizeAngle(objectA.transform.eulerAngles.y);
        float angleB = NormalizeAngle(objectB.transform.eulerAngles.y);
        float angleC = NormalizeAngle(objectC.transform.eulerAngles.y);

        if (angleA == angleB && angleB == angleC)
        {
            Debug.Log("각도 일치");
            if (animator != null)
            {
                animator.SetInteger("Ani_Table_ImagePuzzle_State", 1);
                Destroy(objectA);
                Destroy(objectB);
                Destroy(objectC);               
            }
        }
    }

    float NormalizeAngle(float angle)
    {
        angle = angle % 360;
        if (angle < 0)
        {
            angle += 360;
        }
        return angle;
    }
}

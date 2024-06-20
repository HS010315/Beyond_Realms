using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePuzzle : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;
    public Transform dial1;
    public Transform dial2;
    public Transform dial3;
    public Transform dial4;
    public Animator animator;


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
            }
        }
        CheckLockerDial();
    }



    void CheckLockerDial()
    {
        float dial1Y = NormalizeRotation(dial1.rotation.eulerAngles.y);
        float dial2Y = NormalizeRotation(dial2.rotation.eulerAngles.y);
        float dial3Y = NormalizeRotation(dial3.rotation.eulerAngles.y);
        float dial4Y = NormalizeRotation(dial4.rotation.eulerAngles.y);

        if ((dial1Y == 108 && dial2Y == 216 && dial3Y == 324 && dial4Y == 252) ||
            (dial1Y == -252 && dial2Y == -144 && dial3Y == -36 && dial4Y == -108))
        {
            animator.SetInteger("Ani_Table_ImagePuzzle_State", 2);
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

    float NormalizeRotation(float angle)
    {
        if (angle > 180)
        {
            angle -= 360;
        }
        return angle;
    }

}

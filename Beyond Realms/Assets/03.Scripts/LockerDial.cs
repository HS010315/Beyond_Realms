using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerDial : MonoBehaviour
{
    public Transform dial1;
    public Transform dial2;
    public Transform dial3;
    public Transform dial4;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();    
    }
    // Update is called once per frame
    void Update()
    {
        float dial1Y = dial1.rotation.eulerAngles.y;
        float dial2Y = dial2.rotation.eulerAngles.y;
        float dial3Y = dial3.rotation.eulerAngles.y;
        float dial4Y = dial4.rotation.eulerAngles.y;

        dial1Y = NormalizeRotation(dial1Y);
        dial2Y = NormalizeRotation(dial2Y);
        dial3Y = NormalizeRotation(dial3Y);
        dial4Y = NormalizeRotation(dial4Y);

        if ((dial1Y == 108 && dial2Y == -144 && dial3Y == 324 && dial4Y == 252) ||
            (dial1Y == -252 && dial2Y == 216 && dial3Y == -36 && dial4Y == -108))
        {
            animator.SetInteger("Ani_Table_ImagePuzzle_State", 2);
        }
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

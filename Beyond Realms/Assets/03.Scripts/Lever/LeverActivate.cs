using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivate : MonoBehaviour
{
    public GameObject lever1;
    public GameObject lever2;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        // 레버의 회전 각도를 얻어옴
        float lever1RotationZ = lever1.transform.localEulerAngles.z;
        float lever2RotationZ = lever2.transform.localEulerAngles.z;

        // 레버의 x축 각도가 -45도 이하이면 애니메이터 변수를 1로 설정
        if (lever1RotationZ >= 45f && lever2RotationZ >= 45f)
        {
            animator.SetInteger("LastDoor", 1);
        }
        else
        {
            // -45도가 아니면 애니메이터 변수를 0으로 설정
            animator.SetInteger("LastDoor", 0);
        }
    }
}
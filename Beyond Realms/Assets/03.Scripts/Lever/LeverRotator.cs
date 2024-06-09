using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRotator : MonoBehaviour
{
    public GameObject leverObject;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        // 레버의 회전 각도를 얻어옴
        float leverRotationX = leverObject.transform.rotation.eulerAngles.x;

        // 레버의 x축 각도가 -30도 이하이면 애니메이터 변수를 1로 설정
        if (leverRotationX <= 330f && leverRotationX >= 330f - 90f) 
        {
            animator.SetInteger("TableAni", 1);
        }
        else
        {
            // -45도가 아니면 애니메이터 변수를 0으로 설정
            animator.SetInteger("TableAni", 0);
        }
    }
}
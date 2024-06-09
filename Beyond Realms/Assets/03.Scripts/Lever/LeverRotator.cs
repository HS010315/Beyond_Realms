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
        // ������ ȸ�� ������ ����
        float leverRotationX = leverObject.transform.rotation.eulerAngles.x;

        // ������ x�� ������ -30�� �����̸� �ִϸ����� ������ 1�� ����
        if (leverRotationX <= 330f && leverRotationX >= 330f - 90f) 
        {
            animator.SetInteger("TableAni", 1);
        }
        else
        {
            // -45���� �ƴϸ� �ִϸ����� ������ 0���� ����
            animator.SetInteger("TableAni", 0);
        }
    }
}
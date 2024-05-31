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
        // ������ ȸ�� ������ ����
        float lever1RotationZ = lever1.transform.rotation.eulerAngles.z;
        float lever2RotationX = lever2.transform.rotation.eulerAngles.x;

        // ������ x�� ������ -45�� �����̸� �ִϸ����� ������ 1�� ����
        if (lever1RotationZ <= 360f && lever1RotationZ >= 360f - 90f && lever2RotationX <=315f && lever2RotationX >= 315f - 90f)
        {
            animator.SetInteger("LastDoor", 1);
        }
        else
        {
            // -45���� �ƴϸ� �ִϸ����� ������ 0���� ����
            animator.SetInteger("TableAni", 0);
        }
    }
}
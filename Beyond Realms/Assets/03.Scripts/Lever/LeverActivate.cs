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
        float lever1RotationZ = lever1.transform.localEulerAngles.z;
        float lever2RotationX = lever2.transform.localEulerAngles.x;

        float normalizedLever1RotationZ = NormalizeAngle(lever1RotationZ);
        float normalizedLever2RotationX = NormalizeAngle(lever2RotationX);

        // ������ x�� ������ -45�� �����̸� �ִϸ����� ������ 1�� ����
        if (normalizedLever1RotationZ >= 45f && normalizedLever2RotationX <= -45f)
        {
            animator.SetInteger("LastDoor", 1);
        }
        else
        {
            // -45���� �ƴϸ� �ִϸ����� ������ 0���� ����
            animator.SetInteger("LastDoor", 0);
        }
    }
    float NormalizeAngle(float angle)           //����� ������ ������ ����ϱ� ���� �Լ�
    {
        if (angle > 180f)
        {
            angle -= 360f;
        }
        return angle;
    }
}
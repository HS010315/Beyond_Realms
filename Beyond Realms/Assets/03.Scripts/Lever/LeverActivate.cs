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
        float lever2RotationZ = lever2.transform.localEulerAngles.z;

        // ������ x�� ������ -45�� �����̸� �ִϸ����� ������ 1�� ����
        if (lever1RotationZ >= 45f && lever2RotationZ >= 45f)
        {
            animator.SetInteger("LastDoor", 1);
        }
        else
        {
            // -45���� �ƴϸ� �ִϸ����� ������ 0���� ����
            animator.SetInteger("LastDoor", 0);
        }
    }
}
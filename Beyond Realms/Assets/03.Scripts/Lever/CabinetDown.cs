using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetDown : MonoBehaviour
{
    public GameObject leverObject;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        // ������ ȸ�� ������ ����
        float leverRotationZ = leverObject.transform.rotation.eulerAngles.z;

        // ������ x�� ������ -45�� �����̸� �ִϸ����� ������ 1�� ����
        if (leverRotationZ <= 315f && leverRotationZ >= 315f - 90f)
        {
            animator.SetInteger("Cabinet_Ani", 1);
        }
        else
        {
            // -45���� �ƴϸ� �ִϸ����� ������ 0���� ����
            animator.SetInteger("Cabinet_Ani", 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverRotator : MonoBehaviour
{
    public GameObject leverObject;
    public Animator tableanimator;
    private bool isPawnMoved = false;

    // Update is called once per frame
    void Update()
    {
        // ������ ȸ�� ������ ����
        float leverRotationX = leverObject.transform.rotation.eulerAngles.x;

        // ������ x�� ������ -30�� �����̸� �ִϸ����� ������ 1�� ����
        if (leverRotationX <= 330f && leverRotationX >= 330f - 90f && isPawnMoved) 
        {
            tableanimator.SetInteger("TableAni", 1);
        }
        else
        {
            // -45���� �ƴϸ� �ִϸ����� ������ 0���� ����
            tableanimator.SetInteger("TableAni", 0);
        }
    }
    public void PawnMove()
    {
        isPawnMoved = true;
    }

}
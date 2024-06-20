using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RotationFixer : MonoBehaviour
{
    public float minAngle = -360f;
    public float maxAngle = 360f;
    public float angleDiff = 60f;

    public Transform childTransform; // 자식 오브젝트
    public Transform parentTransform; // 부모 오브젝트
    private Transform originalParent; // 원래 부모 오브젝트
    private Vector3 originalPosition; // 원래 위치

    private void Update()
    {
        float currentAngle = transform.eulerAngles.y;

        currentAngle = Mathf.Repeat(currentAngle, 360f);
        if (currentAngle > 180f)
            currentAngle -= 360f;

        float snappedAngle = Mathf.Round(currentAngle / angleDiff) * angleDiff;

        snappedAngle = Mathf.Clamp(snappedAngle, minAngle, maxAngle);

        transform.eulerAngles = new Vector3(0f, snappedAngle, 0f);
    }
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 자식 오브젝트인지 확인
        if (other.CompareTag("boxPuzzle"))
        {
            // 원래 부모와 위치를 저장
            originalParent = other.transform.parent;
            originalPosition = other.transform.position;

            // 부모 오브젝트에 추가 (월드 좌표계를 유지)
            other.transform.SetParent(parentTransform, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 충돌이 끝난 오브젝트가 자식 오브젝트인지 확인
        if (other.CompareTag("boxPuzzle"))
        {
            // 원래 부모 오브젝트로 복구 (월드 좌표계를 유지)
            other.transform.SetParent(originalParent, true);
            other.transform.position = originalPosition;
        }
    }
}

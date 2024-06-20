using UnityEngine;

public class Parent : MonoBehaviour
{
    public Transform parentTransform; // 부모 오브젝트

    private Transform originalParent; // 원래 부모 오브젝트
    private Vector3 originalPosition; // 원래 위치
    private Quaternion originalRotation; // 원래 회전

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 원하는 오브젝트인지 확인
        if (other.CompareTag("boxPuzzle"))
        {
            // 원래 부모와 위치를 저장
            originalParent = other.transform.parent;
            originalPosition = other.transform.position;
            originalRotation = other.transform.rotation;

            // 부모 오브젝트에 추가 (월드 좌표계를 유지)
            other.transform.SetParent(parentTransform, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 충돌이 끝난 오브젝트가 원하는 오브젝트인지 확인
        if (other.CompareTag("boxPuzzle"))
        {
            // 원래 부모 오브젝트로 복구 (월드 좌표계를 유지)
            other.transform.SetParent(originalParent, true);
            other.transform.position = originalPosition;
            other.transform.rotation = originalRotation;
        }
    }
}
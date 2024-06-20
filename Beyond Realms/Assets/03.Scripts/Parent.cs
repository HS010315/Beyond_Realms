using UnityEngine;

public class Parent : MonoBehaviour
{
    public Transform parentTransform; // �θ� ������Ʈ

    private Transform originalParent; // ���� �θ� ������Ʈ
    private Vector3 originalPosition; // ���� ��ġ
    private Quaternion originalRotation; // ���� ȸ��

    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� ���ϴ� ������Ʈ���� Ȯ��
        if (other.CompareTag("boxPuzzle"))
        {
            // ���� �θ�� ��ġ�� ����
            originalParent = other.transform.parent;
            originalPosition = other.transform.position;
            originalRotation = other.transform.rotation;

            // �θ� ������Ʈ�� �߰� (���� ��ǥ�踦 ����)
            other.transform.SetParent(parentTransform, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // �浹�� ���� ������Ʈ�� ���ϴ� ������Ʈ���� Ȯ��
        if (other.CompareTag("boxPuzzle"))
        {
            // ���� �θ� ������Ʈ�� ���� (���� ��ǥ�踦 ����)
            other.transform.SetParent(originalParent, true);
            other.transform.position = originalPosition;
            other.transform.rotation = originalRotation;
        }
    }
}
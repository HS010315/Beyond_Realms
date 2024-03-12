using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    // �� ������Ʈ ����
    public GameObject doorObject;

    // ���� Y �� �̵� �Ÿ�
    public float doorMoveDistance = -1.6f;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Key"))
        {
            Destroy(gameObject);
            // ���� �����ϴ��� Ȯ�� �� �̵�
            if (doorObject != null)
            {
                // ���� ���� ��ġ
                Vector3 doorPosition = doorObject.transform.position;
                // ���ο� Y ������ ����
                doorPosition.y += doorMoveDistance;
                // ���� ��ġ ������Ʈ
                doorObject.transform.position = doorPosition;
            }
            
        }

    }
}
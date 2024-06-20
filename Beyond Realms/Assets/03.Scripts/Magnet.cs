using UnityEngine;

public class Magnet: MonoBehaviour
{
    public string targetTag = "Key"; // ������� ����� �±�
    public float pullForce = 10f; // ������� ���� ����
    public float stopDistance = 2f; // ���ߴ� �Ÿ�

    void FixedUpdate()
    {
        // �ڱ� �ڽ��� ��ġ
        Vector3 magnetPosition = transform.position;

        // ��� ������Ʈ���� �迭�� ��������
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        // �� ��� ������Ʈ�� ����
        foreach (GameObject target in targets)
        {
            // �ڼ��� ��� ������ �Ÿ� ����
            Vector3 direction = magnetPosition - target.transform.position;

            // ������� ���� ���
            float distance = direction.magnitude;
            float pullStrength = 0f;

            // ���� �Ÿ� �̳��� �ִ� ��� ���߰� �ϱ�
            if (distance > stopDistance)
            {
                pullStrength = Mathf.Clamp(pullForce / distance, 0f, pullForce);
            }
            else
            {
                // ���� �Ÿ� �̳��� ������ ����
                pullStrength = 0f;
            }

            // ��󿡰� ���� ���ϱ�
            target.GetComponent<Rigidbody>().AddForce(direction.normalized * pullStrength);
        }
    }
}
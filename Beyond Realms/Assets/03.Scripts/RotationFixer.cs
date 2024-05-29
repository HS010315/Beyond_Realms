using UnityEngine;

public class RotationFixer : MonoBehaviour
{
    // ���ϴ� ��� �������� �迭
    public float[] targetAngles = { 60f, 120f, 180f, 240f, 300f, 360f };

    // ȸ������ ������ ���� ����
    public float angleTolerance = 5f;

    // ȸ������ ������ �Լ�
    void FixRotationAxis(float currentAngle)
    {
        // ���� ������ ����� ��ȯ
        if (currentAngle < 0)
        {
            currentAngle += 360f;
        }

        float closestTargetAngle = targetAngles[0];

        foreach (float targetAngle in targetAngles)
        {
            // ���� ������ ������ ��ǥ ���� ������ ���� ���
            float angleDifference = Mathf.Abs(currentAngle - targetAngle);

            // ���� ��� ���� ���� ������ ȸ������ ����
            if (angleDifference < angleTolerance)
            {
                closestTargetAngle = targetAngle;
                break;
            }
        }

        // ���� ����� ��ǥ ������ ȸ������ ����
        transform.localEulerAngles = new Vector3(0f, closestTargetAngle, 0f);
    }

    void Update()
    {
        // ���� ���� y �� ���� ���
        float currentAngle = transform.localEulerAngles.y;

        // ������ ȸ���� ���� �Լ��� ����
        FixRotationAxis(currentAngle);
    }
}

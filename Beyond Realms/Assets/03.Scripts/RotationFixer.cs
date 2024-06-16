using UnityEngine;

public class RotationFixer : MonoBehaviour
{
    // ���ϴ� ��� �������� �迭
    public float[] targetAngles = { 60f, 120f, 180f, 240f, 300f, 360f };
    // ȸ������ ������ ���� ����
    public float angleTolerance = 5f;

    public Transform startPoint;
    public Transform endPoint;

    void Update()
    {
        // ���� ���� y �� ���� ���
        float currentAngle = transform.localEulerAngles.y;

        // ������ ȸ���� ���� �Լ��� ����
        FixRotationAxis(currentAngle);
    }
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
        RotatePath(closestTargetAngle);
    } 

    private void RotatePath(float angle)
    {
        // ����� �߽��� �������� ȸ��
        Vector3 pathCenter = (startPoint.position + endPoint.position) / 2.0f;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);

        startPoint.position = RotatePointAroundPivot(startPoint.position, pathCenter, rotation);
        endPoint.position = RotatePointAroundPivot(endPoint.position, pathCenter, rotation);
    }

    private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
    {
        // ���� �ǹ� ��ġ�� �̵�
        Vector3 dir = point - pivot;
        // ������ ȸ��
        dir = rotation * dir;
        // ȸ���� ���� �ٽ� ���� ��ġ�� �̵�
        point = dir + pivot;
        return point;
    }
}

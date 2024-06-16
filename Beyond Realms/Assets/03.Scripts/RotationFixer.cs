using UnityEngine;

public class RotationFixer : MonoBehaviour
{
    // 원하는 양수 각도들의 배열
    public float[] targetAngles = { 60f, 120f, 180f, 240f, 300f, 360f };
    // 회전축을 고정할 각도 범위
    public float angleTolerance = 5f;

    public Transform startPoint;
    public Transform endPoint;

    void Update()
    {
        // 현재 로컬 y 축 각도 얻기
        float currentAngle = transform.localEulerAngles.y;

        // 각도를 회전축 고정 함수에 전달
        FixRotationAxis(currentAngle);
    }
    void FixRotationAxis(float currentAngle)
    {
        // 현재 각도를 양수로 변환
        if (currentAngle < 0)
        {
            currentAngle += 360f;
        }

        float closestTargetAngle = targetAngles[0];

        foreach (float targetAngle in targetAngles)
        {
            // 현재 각도와 각각의 목표 각도 사이의 차이 계산
            float angleDifference = Mathf.Abs(currentAngle - targetAngle);

            // 각도 허용 범위 내에 있으면 회전축을 고정
            if (angleDifference < angleTolerance)
            {
                closestTargetAngle = targetAngle;
                break;
            }
        }

        // 가장 가까운 목표 각도로 회전축을 고정
        transform.localEulerAngles = new Vector3(0f, closestTargetAngle, 0f);
        RotatePath(closestTargetAngle);
    } 

    private void RotatePath(float angle)
    {
        // 경로의 중심을 기준으로 회전
        Vector3 pathCenter = (startPoint.position + endPoint.position) / 2.0f;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);

        startPoint.position = RotatePointAroundPivot(startPoint.position, pathCenter, rotation);
        endPoint.position = RotatePointAroundPivot(endPoint.position, pathCenter, rotation);
    }

    private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
    {
        // 점을 피벗 위치로 이동
        Vector3 dir = point - pivot;
        // 방향을 회전
        dir = rotation * dir;
        // 회전된 점을 다시 원래 위치로 이동
        point = dir + pivot;
        return point;
    }
}

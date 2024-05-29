using UnityEngine;

public class RotationFixer : MonoBehaviour
{
    // 원하는 양수 각도들의 배열
    public float[] targetAngles = { 60f, 120f, 180f, 240f, 300f, 360f };

    // 회전축을 고정할 각도 범위
    public float angleTolerance = 5f;

    // 회전축을 고정할 함수
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
    }

    void Update()
    {
        // 현재 로컬 y 축 각도 얻기
        float currentAngle = transform.localEulerAngles.y;

        // 각도를 회전축 고정 함수에 전달
        FixRotationAxis(currentAngle);
    }
}

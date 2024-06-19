using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public GameObject aniKey;
    public GameObject rotateKey;
    public float targetAngleX = 0f;
    public float targetAngleY = 0f;
    public float targetAngleZ = 0f;

    // 애니메이션 상태 설정 함수를 델리게이트로 정의
    public delegate void SetAnimationState();
    public SetAnimationState setAnimationState;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.CompareTag("Key"))
        {
            Debug.Log(rotateKey);
            Destroy(gameObject);
            rotateKey.SetActive(true);
        }
    }

    void Update()
    {
        if (rotateKey.activeSelf)
        {
            // 현재 회전 값을 저장
            float currentAngleX = rotateKey.transform.eulerAngles.x;
            float currentAngleY = rotateKey.transform.eulerAngles.y;
            float currentAngleZ = rotateKey.transform.eulerAngles.z;

            // 현재 각도 디버그 출력
            Debug.Log($"Current Angles: X = {currentAngleX}, Y = {currentAngleY}, Z = {currentAngleZ}");

            // 각도를 비교할 때 작은 오차를 허용
            if (IsApproximatelyEqual(currentAngleX, targetAngleX) &&
                IsApproximatelyEqual(currentAngleY, targetAngleY) &&
                IsApproximatelyEqual(currentAngleZ, targetAngleZ))
            {
                Debug.Log("각도 일치");
                if (setAnimationState != null)
                {
                    setAnimationState();
                }
            }
        }
    }

    bool IsApproximatelyEqual(float a, float b, float tolerance = 0.1f)
    {
        return Mathf.Abs(a - b) < tolerance;
    }
}
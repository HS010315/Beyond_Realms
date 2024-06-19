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

            // 목표 회전 각도와 비교하여 문을 열기
            if (Mathf.Approximately(currentAngleX, targetAngleX) &&
                Mathf.Approximately(currentAngleY, targetAngleY) &&
                Mathf.Approximately(currentAngleZ, targetAngleZ))
            {
                Debug.Log("각도 일치");
                //Animator animator = doorObject.GetComponent<Animator>();
                //if (animator != null && setAnimationState != null)
                //{
                //   setAnimationState(animator);
                //}
                if (setAnimationState != null)
                {
                    setAnimationState();
                }
            }
        }
    }
}
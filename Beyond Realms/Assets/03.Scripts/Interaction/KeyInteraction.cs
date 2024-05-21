using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public GameObject doorObject;
    public GameObject rotateKey;
    public float targetAngleY = 0f;

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
            // 실시간 생성키의 Y rot 값 == 현재 Y rot 값과 비슷해지면 도어오픈

            // 현재 회전 값을 저장
            float currentAngleY = rotateKey.transform.eulerAngles.y;    // 현재 키의 Y 회전값을 계속해서 업데이트            
            Vector3 currentRotation = rotateKey.transform.localEulerAngles; // 현재 키의 X,Y,Z 회전값을 계속해서 업데이트

            // 목표 회전 각도 설정
            Vector3 targetRotation = new Vector3(currentRotation.x, targetAngleY, currentRotation.z);

            //// 회전을 적용
            //rotateKey.transform.eulerAngles = targetRotation;
            if (Mathf.Approximately(currentAngleY, targetAngleY))
            {
                Debug.Log("각도 일치");
                Animator animator = doorObject.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetInteger("TutorialDoorState", 1);
                }
            } 
        }
    }

}

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
            // �ǽð� ����Ű�� Y rot �� == ���� Y rot ���� ��������� �������

            // ���� ȸ�� ���� ����
            float currentAngleY = rotateKey.transform.eulerAngles.y;    // ���� Ű�� Y ȸ������ ����ؼ� ������Ʈ            
            Vector3 currentRotation = rotateKey.transform.localEulerAngles; // ���� Ű�� X,Y,Z ȸ������ ����ؼ� ������Ʈ

            // ��ǥ ȸ�� ���� ����
            Vector3 targetRotation = new Vector3(currentRotation.x, targetAngleY, currentRotation.z);

            //// ȸ���� ����
            //rotateKey.transform.eulerAngles = targetRotation;
            if (Mathf.Approximately(currentAngleY, targetAngleY))
            {
                Debug.Log("���� ��ġ");
                Animator animator = doorObject.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetInteger("TutorialDoorState", 1);
                }
            } 
        }
    }

}

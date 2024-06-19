using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public GameObject aniKey;
    public GameObject rotateKey;
    public float targetAngleX = 0f;
    public float targetAngleY = 0f;
    public float targetAngleZ = 0f;

    // �ִϸ��̼� ���� ���� �Լ��� ��������Ʈ�� ����
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
            // ���� ȸ�� ���� ����
            float currentAngleX = rotateKey.transform.eulerAngles.x;
            float currentAngleY = rotateKey.transform.eulerAngles.y;
            float currentAngleZ = rotateKey.transform.eulerAngles.z;

            // ��ǥ ȸ�� ������ ���Ͽ� ���� ����
            if (Mathf.Approximately(currentAngleX, targetAngleX) &&
                Mathf.Approximately(currentAngleY, targetAngleY) &&
                Mathf.Approximately(currentAngleZ, targetAngleZ))
            {
                Debug.Log("���� ��ġ");
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
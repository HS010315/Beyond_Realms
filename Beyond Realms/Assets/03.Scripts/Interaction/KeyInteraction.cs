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

            // ���� ���� ����� ���
            Debug.Log($"Current Angles: X = {currentAngleX}, Y = {currentAngleY}, Z = {currentAngleZ}");

            // ������ ���� �� ���� ������ ���
            if (IsApproximatelyEqual(currentAngleX, targetAngleX) &&
                IsApproximatelyEqual(currentAngleY, targetAngleY) &&
                IsApproximatelyEqual(currentAngleZ, targetAngleZ))
            {
                Debug.Log("���� ��ġ");
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
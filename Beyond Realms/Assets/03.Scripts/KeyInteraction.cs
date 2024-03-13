using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public GameObject doorObject;
    public float doorMoveDistance = -1.6f;
    public GameObject rotateKey;
    public float targetAngle = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Key"))
        {
            float currentAngle = rotateKey.transform.rotation.eulerAngles.z;
            Destroy(gameObject);
            rotateKey.SetActive(true);
            if (doorObject != null)
            {
                Vector3 doorPosition = doorObject.transform.position;
                doorPosition.y += doorMoveDistance;
                doorObject.transform.position = doorPosition;
            }
            if (Mathf.Approximately(currentAngle, targetAngle))
            {
                
            }
        }
    }
}
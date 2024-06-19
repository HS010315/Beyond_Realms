using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RotationFixer : MonoBehaviour
{
    private List<Transform> childObjects = new List<Transform>();

    public float minAngle = -360f;
    public float maxAngle = 360f;
    public float angleDiff = 60f;

    private void Update()
    {
        float currentAngle = transform.eulerAngles.y;

        currentAngle = Mathf.Repeat(currentAngle, 360f);
        if (currentAngle > 180f)
            currentAngle -= 360f;

        float snappedAngle = Mathf.Round(currentAngle / angleDiff) * angleDiff;

        snappedAngle = Mathf.Clamp(snappedAngle, minAngle, maxAngle);

        transform.eulerAngles = new Vector3(0f, snappedAngle, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("boxPuzzle") && !childObjects.Contains(other.transform))
        {
            childObjects.Add(other.transform);
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("boxPuzzle") && childObjects.Contains(other.transform))
        {
            childObjects.Remove(other.transform);
            other.transform.SetParent(null);
        }
    }
}

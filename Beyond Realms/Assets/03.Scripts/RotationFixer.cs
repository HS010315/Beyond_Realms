using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RotationFixer : MonoBehaviour
{
    public float minAngle = -360f;
    public float maxAngle = 360f;
    public float angleDiff = 60f;

    public Vector3 tempPos;

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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("boxPuzzle"))
        {
            other.transform.SetParent(transform);
            tempPos = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("boxPuzzle"))
        {
            other.transform.SetParent(null);
            other.transform.position = tempPos;
        }
    }
}

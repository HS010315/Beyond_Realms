using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDialPuzzle : MonoBehaviour
{
    public Transform rotateDial;

    public float[] targetAngles = { 22.5f, 45f, 67.5f, 90f, 112.5f, 135f, 157.5f, 180f, 202.5f, 225f, 247.5f, 270f, 292.5f, 315f, 337.5f };

    [SerializeField] private float threshold = 0.05f;
    [SerializeField] private float deadZone = 0.005f;

    private Vector3 startPos;
    private ConfigurableJoint joint;

    public float rotationTime = 1.0f;

    public bool isPressed = false;
    public bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();

        float randomAngle = targetAngles[Random.Range(0, targetAngles.Length)];
        Vector3 startRotation = rotateDial.localEulerAngles;
        rotateDial.localEulerAngles = new Vector3(startRotation.x, startRotation.y, randomAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1 && this.gameObject.CompareTag("UpButton"))
        {
            isPressed = true;
            StartCoroutine(RotateDial(22.5f));
        }
        if (!isPressed && GetValue() + threshold >= 1 && this.gameObject.CompareTag("DownButton"))
        {
            isPressed = true;
            StartCoroutine(RotateDial(-22.5f));
        }
        if (isPressed && GetValue() - threshold <= 0 && (this.gameObject.CompareTag("DownButton") || this.gameObject.CompareTag("UpButton")))
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Released()
    {
        isPressed = false;
    }

    private float NormalizeAngle(float angle)
    {
        angle = angle % 360f;
        if (angle < 0)
        {
            angle += 360f;
        }
        return angle;
    }
    IEnumerator RotateDial(float angle)
    {
        if (isRotating)
            yield break;

        isRotating = true;

        Vector3 currentRotation = rotateDial.localEulerAngles;
        float startAngle = currentRotation.z;
        float endAngle = NormalizeAngle(startAngle + angle);

        Quaternion startRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, startAngle);
        Quaternion endRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, endAngle);

        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < rotationTime)
        {
            elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / rotationTime);

            rotateDial.localRotation = Quaternion.Lerp(startRotation, endRotation, t);

            yield return null;
        }

        rotateDial.localRotation = endRotation;
        isRotating = false;
    }
}   